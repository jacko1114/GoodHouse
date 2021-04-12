using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Models.ViewModels
{
  public class HouseObjectViewModel
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
    public int Room { get; set; }
    public int LivingRoom { get; set; }
    public int Bathroom { get; set; }
  }

  public class HouseObjectCreateViewModel
  {
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
    public int Room { get; set; }
    public int LivingRoom { get; set; }
    public int Bathroom { get; set; }
  }
}
