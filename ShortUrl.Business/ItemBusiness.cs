using System;
using System.Threading.Tasks;
using ShortUrl.Business.Contract;
using ShortUrl.Business.Models;
using ShortUrl.Data.Commands.Handlers.Contract;
using ShortUrl.Data.Commands.Models.Item;

namespace ShortUrl.Business
{
    internal class ItemBusiness : IItemBusiness
    {
        #region Private Fields
        private readonly IItemCommandHandler _itemCommandHandler;
        #endregion

        #region Constructor
        public ItemBusiness(IItemCommandHandler itemCommandHandler)
        {
            _itemCommandHandler = itemCommandHandler ?? throw new ArgumentNullException(nameof(itemCommandHandler));
        }
        #endregion

        #region Member of IItemBusiness
        public async Task<Response> GenerateAsync(ItemModel model)
        {
            var response = new Response();
            try
            {
                string segment = "";

                await _itemCommandHandler.ExecuteAsync(new CreateItemCommand
                {
                    ExpiredDate = model.ExpiredDate,
                    OriginUrl = model.OriginUrl,
                    Segment = segment
                });

                response.IsSuccess = true;
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