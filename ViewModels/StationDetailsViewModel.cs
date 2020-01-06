using System.Collections.Generic;
using FireFighterApi.ViewModels;

namespace FireStationApi.ViewModels
{
  public class StationDetails
  {
    public int Id { get; set; }

    public string StationName { get; set; }
    public string Address { get; set; }



    public List<CreatedFireFighter> FireFighters { get; set; }
      = new List<CreatedFireFighter>();
  }
}