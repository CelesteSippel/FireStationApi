namespace FireFighterApi.ViewModels
{
  public class CreatedFireFighter
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Rank { get; set; }
    public bool Driver { get; set; } = true;
    public int StationId { get; set; }
  }
}