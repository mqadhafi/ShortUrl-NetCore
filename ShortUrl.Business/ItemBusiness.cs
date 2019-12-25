using System;
using System.Threading.Tasks;
using ShortUrl.Business.Contract;
using ShortUrl.Business.Extensions;
using ShortUrl.Business.Models;
using ShortUrl.Command.Handlers.Contract;
using ShortUrl.Command.Models;
using ShortUrl.Domain.Entities;
using ShortUrl.Query.Handlers.Contract;

namespace ShortUrl.Business
{
    internal class ItemBusiness : IItemBusiness
    {
        #region Private Fields
        private readonly IItemCommandHandler _itemCommandHandler;
        private readonly IStatisticCommandHandler _statisticCommandHandler;
        private readonly IItemQueryHandler _itemQueryHandler;
        #endregion

        #region Constructor
        public ItemBusiness(
            IItemCommandHandler itemCommandHandler,
            IStatisticCommandHandler statisticCommandHandler,
            IItemQueryHandler itemQueryHandler)
        {
            _itemCommandHandler = itemCommandHandler ?? throw new ArgumentNullException(nameof(itemCommandHandler));
            _statisticCommandHandler = statisticCommandHandler ?? throw new ArgumentNullException(nameof(statisticCommandHandler));
            _itemQueryHandler = itemQueryHandler ?? throw new ArgumentNullException(nameof(itemQueryHandler));
        }
        #endregion

        #region Member of IItemBusiness
        public async Task<GeneratorResponse> GenerateAsync(GeneratorRequest model)
        {
            var response = new GeneratorResponse();
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

                Item entity = await _itemQueryHandler.GetBySegmentAsync(model.OriginUrl);
                string segment = entity?.Segment;

                if (string.IsNullOrWhiteSpace(segment))
                {
                    // generate new segment
                    segment = KeyGeneratorExtension.GetUniqueKey(8);

                    await _itemCommandHandler.ExecuteAsync(new CreateItemCommand
                    {
                        IpAddress = model.IpAddress,
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

        public async Task<RedirectResponse> NavigatesAsync(RedirectRequest model)
        {
            var response = new RedirectResponse();
            try
            {
                Item entity = await _itemQueryHandler.GetByOriginUrlAsync(model.Segment);

                if (entity != null && !string.IsNullOrWhiteSpace(entity.OriginUrl))
                {
                    // logging history to the DB
                    await _statisticCommandHandler.ExecuteAsync(new CreateStatisticCommand
                    {
                        IpAddress = model.IpAddress,
                        ItemId = entity.Id
                    });

                    response.IsSuccess = true;
                    response.OriginUrl = entity.OriginUrl;
                }
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