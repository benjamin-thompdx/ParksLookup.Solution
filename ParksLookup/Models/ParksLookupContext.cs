using Microsoft.EntityFrameworkCore;

namespace ParksLookup.Models
{
  public class ParksLookupContext : DbContext
  {
    public ParksLookupContext(DbContextOptions<ParksLookupContext> options)
      :base(options)
      {

      }

    public DbSet<Park> Parks { get; set; }
    public DbSet<Detail> Details { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Management = "National", Name = "Great Basin National Park", Location = "Baker, NV"},
          new Park { ParkId = 2, Management = "National", Name = "Tule Springs Fossil Beds National Monument", Location = "Las Vegas, NV"},
          new Park { ParkId = 3, Management = "State", Name = "Sand Harbor", Location = "Incline Village, NV"},
          new Park { ParkId = 4, Management = "State", Name = "Van Sickle", Location = "South Lake Tahoe, CA"}
        );
      builder.Entity<Detail>()
        .HasData(
          new Detail { DetailId = 1, Description = "Ancient bristlecone pines", Address = "5500 W Hwy 488, Baker, NV 89311", Rating = 5, ParkId = 1},
          new Detail { DetailId = 2, Description = "Established as the 405th unit of the National Park Service.", Address = "16001 Corn Creek Rd, Las Vegas, NV 89166", Rating = 2, ParkId = 2},
          new Detail { DetailId = 3, Description = "The largest alpine lake in North America.", Address = "2005 NV-28, Incline Village, NV 89452", Rating = 5, ParkId = 3},
          new Detail { DetailId = 4, Description = "One the most accessible parks in the Tahoe Basin.", Address = "30 Lake Pkwy, South Lake Tahoe, CA 96150", Rating = 3, ParkId = 4}
        );
    }
  }
}