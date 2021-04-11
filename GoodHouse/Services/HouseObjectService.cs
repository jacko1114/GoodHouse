using GoodHouse.Models.Entity;
using GoodHouse.Repositories;
using GoodHouse.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Services
{
  public class HouseObjectService : IHouseObjectService
  {
    private readonly HouseObjectRepository _repo;
    public HouseObjectService(IConfiguration config)
    {
      _repo = new HouseObjectRepository(config);
    }
    public Task<IEnumerable<HouseObject>> GetHouseObjects()
    {
      return _repo.GetAll();
    }
  }
}
