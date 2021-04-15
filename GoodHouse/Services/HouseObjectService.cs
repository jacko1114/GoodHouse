using GoodHouse.Models.Entity;
using GoodHouse.Models.ViewModels;
using GoodHouse.Repositories;
using GoodHouse.Services.Interfaces;
using GoodHouse.Utilities;
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
    public Task<IEnumerable<HouseObject>> GetHouseObjectsByCondition(Dictionary<string, object> conditions)
    {

      string conditionStrings = string.Empty;

      List<string> condition = new();

      foreach (var kvp in conditions)
      {
        condition.Add($"{kvp.Key}=${kvp.Value}");
      }

      conditionStrings += string.Join(",", condition);

      return _repo.GetByCondition(conditionStrings);
    }
    public Task<OperationResult> CreateHouseObjects(HouseObjectCreateViewModel obj)
    {
      var housingLayoutId = Guid.NewGuid();

      var houseObj = new HouseObject
      {
        HouseObjectId = Guid.NewGuid(),
        HousingLayoutId = housingLayoutId,
        DealDate = obj.DealDate,
        Address = obj.Address,
        HouseAge = obj.HouseAge,
        County = obj.County,
        IsParkingSpace = obj.IsParkingSpace,
        ParkingSpacePrice = obj.ParkingSpacePrice,
        ParkingSpaceSqureFeet = obj.ParkingSpaceSqureFeet,
        Region = obj.Region,
        Remark = obj.Remark,
        Source = obj.Source,
        SquareFeet = obj.SquareFeet,
        SquareFeetUnitPrice = obj.SquareFeetUnitPrice,
        TotalFloor = obj.TotalFloor,
        TotalPrice = obj.TotalPrice,
        Type = obj.Type,
        ImgUrl = obj.ImgUrl,
        Floor = obj.Floor,
        CreateTime = DateTime.UtcNow.AddHours(8),
        EditeTime = DateTime.UtcNow.AddHours(8),
        CreateUser = "Jacko",
        EditeUser = "Jacko",
      };
      var housingLayout = new HousingLayout
      {
        HousingLayoutId = housingLayoutId,
        Bathroom = obj.Bathroom,
        LivingRoom = obj.LivingRoom,
        Room = obj.Room,
        EditeTime = DateTime.UtcNow.AddHours(8),
        CreateTime = DateTime.UtcNow.AddHours(8),
        CreateUser = "Jacko",
        EditeUser = "Jacko"
      };
      var result = _repo.Insert(houseObj, housingLayout);

      return result;
    }
    public Task<OperationResult> UpdateHouseObject(HouseObjectViewModel obj)
    {
      var houseObj = new HouseObject
      {
        HouseObjectId = obj.HouseObjectId,
        DealDate = obj.DealDate,
        Address = obj.Address,
        HouseAge = obj.HouseAge,
        County = obj.County,
        IsParkingSpace = obj.IsParkingSpace,
        ParkingSpacePrice = obj.ParkingSpacePrice,
        ParkingSpaceSqureFeet = obj.ParkingSpaceSqureFeet,
        Region = obj.Region,
        Remark = obj.Remark,
        Source = obj.Source,
        SquareFeet = obj.SquareFeet,
        SquareFeetUnitPrice = obj.SquareFeetUnitPrice,
        TotalFloor = obj.TotalFloor,
        TotalPrice = obj.TotalPrice,
        Type = obj.Type,
        ImgUrl = obj.ImgUrl,
        Floor = obj.Floor,
        CreateTime = DateTime.UtcNow.AddHours(8),
        EditeTime = DateTime.UtcNow.AddHours(8),
        CreateUser = "Jacko",
        EditeUser = "Jacko",
      };
      var housingLayout = new HousingLayout
      {
        HousingLayoutId = obj.HousingLayoutId,
        Bathroom = obj.Bathroom,
        LivingRoom = obj.LivingRoom,
        Room = obj.Room,
        EditeTime = DateTime.UtcNow.AddHours(8),
        CreateTime = DateTime.UtcNow.AddHours(8),
        CreateUser = "Jacko",
        EditeUser = "Jacko"
      };
      var result = _repo.Insert(houseObj, housingLayout);

      return result;
    }
    public Task<OperationResult> DeleteHouseObject(Guid houseObjectId) {

      var condition = new Dictionary<string, object> { 
        ["HousingLayoutId"] = houseObjectId 
      };
      var result = GetHouseObjectsByCondition(condition).Result.FirstOrDefault();
      if(result != null)
      {
        return _repo.Delete(result);
      }
      else
      {
        throw new Exception();
      }
    }
  }
}
