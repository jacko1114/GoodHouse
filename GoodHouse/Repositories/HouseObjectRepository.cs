using Dapper;
using GoodHouse.Models.Entity;
using GoodHouse.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Repositories
{
  public class HouseObjectRepository :BaseRepository<HouseObject>,IGenericRepository<HouseObject>
  {
    public HouseObjectRepository(IConfiguration config): base(config) { }

    public async Task<IEnumerable<HouseObject>> GetAll()
    {
      string query = "Select * From HouseObjects Inner Join HousingLayouts On HouseObjects.HousingLayoutId = HousingLayouts.HousingLayoutId";
      return await _conn.QueryAsync<HouseObject>(query);
    }

    public void Delete(HouseObject t)
    {
      throw new NotImplementedException();
    }


    public void Insert(HouseObject t)
    {
      throw new NotImplementedException();
    }

    public void Update(HouseObject t)
    {
      throw new NotImplementedException();
    }
  }
}
