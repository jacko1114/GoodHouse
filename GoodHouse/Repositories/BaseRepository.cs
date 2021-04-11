using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Repositories
{
  public class BaseRepository<T> where T : class
  {
    private readonly IConfiguration _config;
    protected SqlConnection _conn;
    public BaseRepository(IConfiguration config)
    {
      _config = config;
      if (_conn == null)
      {
        _conn = new SqlConnection(_config["ConnectionStrings:GoodHouseDbContext"]);
      }
    }
  }
}
