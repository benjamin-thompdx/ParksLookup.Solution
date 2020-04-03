using System.ComponentModel.DataAnnotations;
using ParksLookup.Entities;

namespace ParksLookup.Models
{
  public class Detail
  {
    public int DetailId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
    public int ParkId { get; set; } = 0;
    public virtual User User { get; set; }
  }
}