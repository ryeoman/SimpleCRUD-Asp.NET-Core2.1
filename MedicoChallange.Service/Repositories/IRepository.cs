using Medico.Challange.DL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medico.Challange.Services.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        ApplicationMainDbContext GetContext();
        Task<T> GetByIdAsync(string id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
