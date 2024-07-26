using AutoMapper;
using AutoMapper.QueryableExtensions;
using FanApp.Common.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FanApp.Endpoints.Services
{
    public class EntityResultBuilder<TEntity, TOutput> where TEntity : DbEntity
    {
        private IQueryable<TEntity> _entityQuery;
        private readonly IMapper _mapper;

        public EntityResultBuilder(DbSet<TEntity> queryable, IMapper mapper) 
        {
            _entityQuery = queryable.AsQueryable();
            _mapper = mapper;
        }
        //public EntityResultBuilder(IQueryable<TEntity> queryable, IMapper mapper) 
        //{
        //    _entityQuery = queryable.AsQueryable();
        //    _mapper = mapper;
        //}

        public void AddWhereExpression(Expression<Func<TEntity, bool>> whereExpression)
        {
            if (whereExpression is not null)
            {
                _entityQuery = _entityQuery.Where(whereExpression);
            }
        }
        public async Task<List<TOutput>> ToMappedResultAsync()
        {
            return await _entityQuery
                .ProjectTo<TOutput>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
