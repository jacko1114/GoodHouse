using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Models.Entity
{
  public class HouseObject : BaseEntity
  {
    public Guid HouseObjectId { get; set; }
    public Guid HousingLayoutId { get; set; }
    public DateTime DealDate { get; set; }
    public string Type { get; set; }
    public string County { get; set; }
    public string Region { get; set; }
    public string Address { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal SquareFeet { get; set; }
    public decimal SquareFeetUnitPrice { get; set; }
    public int Floor { get; set; }
    public int TotalFloor { get; set; }
    public decimal HouseAge { get; set; }
    public string ImgUrl { get; set; }
    public string Source { get; set; }
    public string Remark { get; set; }
    public bool IsParkingSpace { get; set; }
    public decimal ParkingSpacePrice { get; set; }
    public decimal ParkingSpaceSqureFeet { get; set; }
  }
}
