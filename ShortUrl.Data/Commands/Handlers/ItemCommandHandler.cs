using System;
using System.Threading.Tasks;
using AutoMapper;
using ShortUrl.Data.Commands.Handlers.Contract;
using ShortUrl.Data.Commands.Models;
using ShortUrl.Data.Commands.Models.Item;
using ShortUrl.Data.Context;
using ShortUrl.Data.Entities;

namespace ShortUrl.Data.Commands.Handlers
{
    internal class ItemCommandHandler : IItemCommandHandler
    {
        #region Private Fields
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ItemCommandHandler(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Member of IItemCommandHandler
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<Response> ExecuteAsync(CreateItemCommand command)
        {
            var response = new Response();
            try
            {
                // map object
                Item entity = _mapper.Map<CreateItemCommand, Item>(command);

                // entity added
                _dbContext.Set<Item>().Add(entity);

                // commit changes
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

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