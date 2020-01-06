namespace FireStationApi.Models
{
  public class FireFighter
  {

    public int Id { get; set; }

    public string FullName { get; set; }
    public string Rank { get; set; }
    public bool Driver { get; set; } = true;
    public int StationId { get; set; }

    public Station Station { get; set; }

  }
}