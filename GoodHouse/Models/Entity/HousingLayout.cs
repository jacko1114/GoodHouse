using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Models.Entity
{
  public class HousingLayout : BaseEntity
  {
    public Guid HousingLayoutId { get; set; }
    public int Room { get; set; }
    public int LivingRoom { get; set; }
    public int Bathroom { get; set; }
  }
}
