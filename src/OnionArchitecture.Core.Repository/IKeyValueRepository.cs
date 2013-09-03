using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Core.Repository
{
    public interface IKeyValueRepository<T> where T : class
    {
        T GetById(string id);
        IList<T> GetByIds(ICollection<string> ids);
        IList<T> GetAll();
        void Store(T entity);
        void StoreAll(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteById(string id);
        void DeleteByIds(ICollection<string> ids);
        void DeleteAll();
    }
}
