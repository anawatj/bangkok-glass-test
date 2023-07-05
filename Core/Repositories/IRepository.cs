using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<E,T> where E :BaseDomain<T>
    {
        E Add(E entity);
        E Update(E entity, T id);

        void Delete(T id);

        E FindById(T id);

        List<E> FindAll();
    }
}
