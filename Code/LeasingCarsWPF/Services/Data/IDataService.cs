using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LeasingCarsWPF.Models;

namespace LeasingCarsWPF.Services.Data
{
    public interface IDataService<T> where T : BaseModel
    {
        public Task<T> Get(long id);
        public Task<int> Add(T entity);
        public Task<int> Update(long id, T entity);
        public Task<List<T>> GetAll();
        public Task<int> Delete(long id);
        public Task<T> FirsOrDefault(Expression<Func<T, bool>> pred);
        public List<T> Get(Expression<Func<T, bool>> pred);
        public Task<List<T>> GetWithInclude(params Expression<Func<T, object>>[] includes);
    }
}