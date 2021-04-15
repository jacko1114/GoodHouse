using GoodHouse.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Repositories.Interfaces
{
  public interface IGenericRepository<TEntity,TEntity2> where TEntity : class
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<OperationResult> Insert(TEntity t,TEntity2 t2);
    Task<OperationResult> Update(TEntity t,TEntity2 t2);
    Task<OperationResult> Delete(TEntity t);
  }
}
