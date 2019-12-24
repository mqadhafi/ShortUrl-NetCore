using System;
using System.Threading.Tasks;
using AutoMapper;
using ShortUrl.Commands.Handlers.Contract;
using ShortUrl.Commands.Models;
using ShortUrl.Domain.Context;
using ShortUrl.Domain.Entities;

namespace ShortUrl.Commands.Handlers
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
        public async Task ExecuteAsync(CreateItemCommand command)
        {
            // map object
            Item entity = _mapper.Map<CreateItemCommand, Item>(command);

            // entity added
            _dbContext.Set<Item>().Add(entity);

            // commit changes
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}