using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FireStationApi.Models;
using FireStationApi.ViewModels;
using FireFighterApi.ViewModels;

namespace FireStationApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StationController : ControllerBase
  {

    [HttpGet]
    public ActionResult GetAllStations()
    {
      // return a list of all students ordered by fullname
      var db = new DatabaseContext();
      return Ok(db.Stations.OrderBy(station => station.StationName));
    }

    [HttpGet("{id}")]
    public ActionResult GetOneStation(int id)
    {
      var db = new DatabaseContext();
      var station = db.Stations.Include(i => i.FireFighters).FirstOrDefault(st => st.Id == id);
      if (station == null)
      {
        return NotFound();
      }
      else
      {
        // create our json object
        var rv = new StationDetails
        {
          Id = station.Id,
          StationName = station.StationName,
          Address = station.Address,
          FireFighters = station.FireFighters.Select(ff => new CreatedFireFighter
          {
            FullName = ff.FullName,
            Rank = ff.Rank,
            Driver = ff.Driver,
            StationId = ff.StationId,
            Id = ff.Id
          }).ToList()
        };
        return Ok(rv);
      }
    }

    [HttpPost]
    public ActionResult CreateStation(Station station)
    {
      var db = new DatabaseContext();
      station.Id = 0;
      db.Stations.Add(station);
      db.SaveChanges();
      return Ok(station);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateStation(Station station)
    {
      var db = new DatabaseContext();
      var prevStation = db.Stations.FirstOrDefault(st => st.Id == station.Id);
      if (prevStation == null)
      {
        return NotFound();
      }
      else
      {
        prevStation.StationName = station.StationName;
        prevStation.Address = station.Address;

        db.SaveChanges();
        return Ok(prevStation);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteStation(int id)
    {
      var db = new DatabaseContext();
      var station = db.Stations.FirstOrDefault(st => st.Id == id);
      if (station == null)
      {
        return NotFound();
      }
      else
      {
        db.Stations.Remove(station);
        db.SaveChanges();
        return Ok();
      }
    }

  }
}