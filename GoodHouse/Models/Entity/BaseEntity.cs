using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Models.Entity
{
  public class BaseEntity
  {
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime EditeTime { get; set; }
    public string EditeUser { get; set; }
  }
}
