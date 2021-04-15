using GoodHouse.Models.Entity;
using GoodHouse.Models.ViewModels;
using GoodHouse.Services.Interfaces;
using GoodHouse.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GoodHouse.WebApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HouseObjectApiController : ControllerBase
  {
    private readonly IHouseObjectService _houseObjectService;

    public HouseObjectApiController(IHouseObjectService houseObjectService)
    {
      _houseObjectService = houseObjectService;
    }

    [HttpGet("getAllData")]
    public async Task<object> AllData()
    {
      return await _houseObjectService.GetHouseObjects();
    }

    [HttpGet("getConditionData")]
    public async Task<object> ConditionData(HouseObjectViewModel obj)
    {
      Dictionary<string, object> conditions = new();

      Type typeObj = obj.GetType();
      PropertyInfo[] propertyList = typeObj.GetProperties();

      foreach (var property in propertyList)
      {
        conditions.Add(property.Name, property.GetValue(typeObj, null));
      }
      return await _houseObjectService.GetHouseObjectsByCondition(conditions);
    }

    [HttpPost("createData")]
    public async Task<OperationResult> CreateData(HouseObjectCreateViewModel obj)
    {
      return await _houseObjectService.CreateHouseObjects(obj);
    }

    [HttpPost("updateData")]
    public async Task<OperationResult> UpdateData(HouseObjectViewModel obj)
    {
      return await _houseObjectService.UpdateHouseObject(obj);
    }

    [HttpPost("deleteData")]
    public async Task<OperationResult> DeleteData(HouseObjectViewModel obj)
    {
      return await _houseObjectService.DeleteHouseObject(obj.HouseObjectId);
    }
  }
}
