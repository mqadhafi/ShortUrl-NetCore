using System;
using System.Threading.Tasks;
using AutoMapper;
using ShortUrl.Command.Handlers.Contract;
using ShortUrl.Command.Models;
using ShortUrl.Domain.Context;
using ShortUrl.Domain.Entities;

namespace ShortUrl.Command.Handlers
{
    internal class StatisticCommandHandler : IStatisticCommandHandler
    {
        #region Private Fields
        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StatisticCommandHandler(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Member of IStatisticCommandHandler
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(CreateStatisticCommand command)
        {
            // map object
            Statistic entity = _mapper.Map<CreateStatisticCommand, Statistic>(command);

            // entity added
            _dbContext.Set<Statistic>().Add(entity);

            // commit changes
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}