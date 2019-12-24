using System;
using System.Threading.Tasks;
using ShortUrl.Business.Contract;
using ShortUrl.Business.Extensions;
using ShortUrl.Business.Models.Item;
using ShortUrl.Commands.Handlers.Contract;
using ShortUrl.Commands.Models;
using ShortUrl.Query.Handlers.Contract;

namespace ShortUrl.Business
{
    internal class ItemBusiness : IItemBusiness
    {
        #region Private Fields
        private readonly IItemCommandHandler _itemCommandHandler;
        private readonly IItemQueryHandler _itemQueryHandler;
        #endregion

        #region Constructor
        public ItemBusiness(IItemCommandHandler itemCommandHandler, IItemQueryHandler itemQueryHandler)
        {
            _itemCommandHandler = itemCommandHandler ?? throw new ArgumentNullException(nameof(itemCommandHandler));
            _itemQueryHandler = itemQueryHandler ?? throw new ArgumentNullException(nameof(itemQueryHandler));
        }
        #endregion

        #region Member of IItemBusiness
        public async Task<ItemResponse> GenerateAsync(ItemRequest model)
        {
            var response = new ItemResponse();
            try
            {
                if (model == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Empty model";
                    return response;
                }
                if (string.IsNullOrWhiteSpace(model.OriginUrl))
                {
                    response.IsSuccess = false;
                    response.Message = "Empty origin url";
                    return response;
                }

                string segment = await _itemQueryHandler.IsExistAsync(model.OriginUrl);

                if (string.IsNullOrWhiteSpace(segment))
                {
                    // generate new segment
                    segment = KeyGeneratorExtension.GetUniqueKey(8);

                    await _itemCommandHandler.ExecuteAsync(new CreateItemCommand
                    {
                        ExpiredDate = model.ExpiredDate,
                        OriginUrl = model.OriginUrl,
                        Segment = segment
                    });
                }

                response.IsSuccess = true;
                response.Segment = segment;
            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.Message = exception.Message;
            }
            return response;
        }
        #endregion
    }
}