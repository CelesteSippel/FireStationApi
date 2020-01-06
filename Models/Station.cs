using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FireStationApi.Models
{
  public class Station
  {
    public int Id { get; set; }

    [Required]
    public string StationName { get; set; }

    [Required]
    public string Address { get; set; }


    public List<FireFighter> FireFighters { get; set; }
      = new List<FireFighter>();
  }
}