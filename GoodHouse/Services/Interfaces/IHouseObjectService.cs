using GoodHouse.Models.Entity;
using GoodHouse.Models.ViewModels;
using GoodHouse.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Services.Interfaces
{
  public interface IHouseObjectService
  {
    Task<IEnumerable<HouseObject>> GetHouseObjects();
    Task<IEnumerable<HouseObject>> GetHouseObjectsByCondition(Dictionary<string, object> conditions);
    OperationResult CreateHouseObjects(HouseObjectCreateViewModel obj);
    OperationResult UpdateHouseObject(HouseObjectViewModel obj);
    OperationResult DeleteHouseObject(Guid houseObjectId);
  }
}
