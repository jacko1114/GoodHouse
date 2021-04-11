using GoodHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Services.Interfaces
{
  public interface IHouseObjectService
  {
    Task<IEnumerable<HouseObject>> GetHouseObjects();
  }
}
