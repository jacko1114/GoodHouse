using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Repositories.Interfaces
{
  public interface IGenericRepository<TEntity> where TEntity : class
  {
    Task<IEnumerable<TEntity>> GetAll();
    void Insert(TEntity t);
    void Update(TEntity t);
    void Delete(TEntity t);
  }
}
