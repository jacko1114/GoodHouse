using GoodHouse.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHouse.Models
{
  public class GoodHouseDbContext : DbContext
  {
    public GoodHouseDbContext(DbContextOptions<GoodHouseDbContext> options): base(options)
    {
    }

    public DbSet<HouseObject> HouseObjects { get; set; }
    public DbSet<HousingLayout> HousingLayouts { get; set; }
  }
}
