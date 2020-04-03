using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParksLookup.Models
{
  public class Park
  {
    public Park()
    {
      this.Details = new HashSet<Detail>();
    }

    public int ParkId { get; set; }
    [Required]
    public string Management { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    
    public virtual ICollection<Detail> Details { get; set; }
  }
}