using Dapper;
using GoodHouse.Models.Entity;
using GoodHouse.Repositories.Interfaces;
using GoodHouse.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GoodHouse.Repositories
{
  public class HouseObjectRepository : BaseRepository<HouseObject>, IGenericRepository<HouseObject, HousingLayout>
  {
    public HouseObjectRepository(IConfiguration config) : base(config) { }

    public async Task<IEnumerable<HouseObject>> GetAll()
    {
      //string query = "Select * From HouseObjects Inner Join HousingLayouts On HouseObjects.HousingLayoutId = HousingLayouts.HousingLayoutId";
      string query = "Select * From HouseObjects";
      var result = await _conn.QueryAsync<HouseObject>(query);
      return result;
    }

    public async Task<IEnumerable<HouseObject>> GetByCondition(string conditionStrings)
    {
      string query = $"Select * From HouseObjects Where {conditionStrings} Inner Join HousingLayouts On HouseObjects.HousingLayoutId = HousingLayouts.HousingLayoutId";
      return await _conn.QueryAsync<HouseObject>(query);
    }

    public async Task<OperationResult> Insert(HouseObject obj, HousingLayout layout)
    {
      OperationResult result = new();
      var (objKeys, objValues) = GetArray<HouseObject>(obj);
      var (layoutKeys, layoutValues) = GetArray<HousingLayout>(layout);
      string houseObjectQuery = $"Insert Into HouseObjects ({string.Join(",", objKeys)}) Values ({string.Join(",", objValues)})";
      string housingLayoutQuery = $"Insert Into HousingLayouts ({string.Join(",", layoutKeys)}) Values ({string.Join(",", layoutValues)})";

      _conn.Open();

      using (var _tran = _conn.BeginTransaction())
      {
        try
        {
          await _conn.ExecuteAsync(houseObjectQuery);
          await _conn.ExecuteAsync(housingLayoutQuery);
          result.IsSuccessful = true;
          _tran.Commit();
        }
        catch (Exception ex)
        {
          await _tran.RollbackAsync();
          result.IsSuccessful = false;
          result.Exception = ex;
        }
      }
      return result;
    }

    public async Task<OperationResult> Update(HouseObject obj, HousingLayout layout)
    {
      OperationResult result = new();
      var (objKeys, objValues) = GetArray<HouseObject>(obj);
      var (layoutKeys, layoutValues) = GetArray<HousingLayout>(layout);
      var objStrings = string.Empty;
      var layoutStrings = string.Empty;
      for (int i = 0; i < objKeys.Length; i++)
      {
        if (objValues[i] != null) {
          objStrings += $"{objKeys[i]}=${objValues[i]}";
        }
      }
      for (int i = 0; i < layoutKeys.Length; i++)
      {
        if (layoutValues[i] != null)
        {
          layoutStrings += $"{layoutKeys[i]}=${layoutValues[i]}";
        }
      }

      string houseObjectQuery = $"Update HouseObjects Set({objStrings}) Where HouseObjectId={obj.HouseObjectId}";
      string housingLayoutQuery = $"Update HousingLayouts Set({layoutStrings}) Where HousingLayoutId={layout.HousingLayoutId}";

      using (var _tran = _conn.BeginTransaction())
      {
        try
        {
          await _conn.ExecuteAsync(houseObjectQuery);
          await _conn.ExecuteAsync(housingLayoutQuery);
          result.IsSuccessful = true;
          _tran.Commit();
        }
        catch (Exception ex)
        {
          await _tran.RollbackAsync();
          result.IsSuccessful = false;
          result.Exception = ex;
        }
      }
      return result;
    }

    public async Task<OperationResult> Delete(HouseObject obj)
    {
      OperationResult result = new();

      string deleteHouseObjectQuery = $"Delete From HouseObjects Where HouseObjectId={obj.HouseObjectId}";

      string deletehousingLayoutQuery = $"Delete From HousingLayouts Where HousingLayoutId={obj.HousingLayoutId}";

      using (var _tran = _conn.BeginTransaction())
      {
        try
        {
          await _conn.ExecuteAsync(deleteHouseObjectQuery);
          await _conn.ExecuteAsync(deletehousingLayoutQuery);
          result.IsSuccessful = true;
          _tran.Commit();
        }
        catch (Exception ex)
        {
          await _tran.RollbackAsync();
          result.IsSuccessful = false;
          result.Exception = ex;
        }
      }
      return result;
    }

    public (string[], object[]) GetArray<T>(T obj) where T : class
    {
      Type typeObj = obj.GetType();
      PropertyInfo[] propertyList = typeObj.GetProperties();
      string[] keys = propertyList.Select(x => x.Name).ToArray();
      object[] values = propertyList.Select(x => x.GetValue(obj,null)).ToArray();

      return (keys, values);
    }
  }
}
