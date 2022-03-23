using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LeasingCarsWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace LeasingCarsWPF.Services.Data
{
    public class DataService<T> : IDataService<T> where T : BaseModel 
    {
        private IDbContextFactory<LeasingCarsDbContext> _contextFactory;

        public DataService(IDbContextFactory<LeasingCarsDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Get(long id)
        {
            T entity;
            await using (var context = _contextFactory.CreateDbContext())
            {
                entity = await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            }
            return entity;
        }

        public async Task<int> Add(T entity)
        {
            await using (var context = _contextFactory.CreateDbContext())
            {
                await context.Set<T>().AddAsync(entity);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> Update(long id, T entity)
        {
            await using (var context = _contextFactory.CreateDbContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<T, T>().ForMember(x => x.Id, opt => opt.Ignore()));
                var mapper = new Mapper(config);
                var entityToUpdate = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                //context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                entityToUpdate = mapper.Map<T>(entity);
                context.Set<T>().Update(entityToUpdate);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            List<T> entities;
            await using (var context = _contextFactory.CreateDbContext())
            {
                entities =  await context.Set<T>().AsNoTracking().ToListAsync();
            }
            return entities;
        }

        public async Task<int> Delete(long id)
        {
            await using (var context = _contextFactory.CreateDbContext())
            {
                var entityToDelete = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                context.Set<T>().Remove(entityToDelete);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<T> FirsOrDefault(Expression<Func<T,bool>> pred)
        {
            T entity;
            await using (var context = _contextFactory.CreateDbContext())
            {
                entity =  await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(pred);
            }

            return entity;
        }

        public List<T> Get(Expression<Func<T, bool>> pred)
        {
            List<T> entities;
            using (var context = _contextFactory.CreateDbContext())
            {
                entities =  context.Set<T>().AsNoTracking().Where(pred).ToList();
            }

            return entities;
        }

        public async Task<List<T>> GetWithInclude(params Expression<Func<T, object>>[] includes)
        {
            List<T> entities;
            using (var context = _contextFactory.CreateDbContext())
            {
                var query = context.Set<T>().AsNoTracking();
                entities =  await includes
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty))
                    .ToListAsync();
            }
            return entities;
        }
    }
}