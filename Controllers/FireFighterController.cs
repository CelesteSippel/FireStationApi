using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FireStationApi.Models;
using FireStationApi.ViewModels;
using FireFighterApi.ViewModels;

namespace StudentApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FireFighterController : ControllerBase
  {

    [HttpGet]
    public ActionResult GetAllFireFighters()
    {
      // return a list of all firefighters ordered by fullname
      var db = new DatabaseContext();
      return Ok(db.FireFighters.OrderBy(fireFighter => fireFighter.FullName));
    }


    [HttpGet("{id}")]
    public ActionResult GetOneFireFighter(int id)
    {
      var db = new DatabaseContext();
      var fireFighter = db.FireFighters.FirstOrDefault(fireFighter => fireFighter.Id == id);
      if (fireFighter == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(fireFighter);
      }
    }

    [HttpPost]
    public ActionResult CreateFireFighter(NewFireFighterViewModel vm)
    {
      var db = new DatabaseContext();
      var station = db.Stations
        .FirstOrDefault(station => station.Id == vm.StationId);
      if (station == null)
      {
        return NotFound();
      }
      else
      {
        var probie = new FireFighter
        {
          FullName = vm.FullName,
          Rank = vm.Rank,
          StationId = vm.StationId,
          Driver = vm.Driver
        };
        db.FireFighters.Add(probie);
        db.SaveChanges();
        var rv = new CreatedFireFighter
        {
          Id = probie.Id,
          FullName = probie.FullName,
          Rank = probie.Rank,
          StationId = probie.StationId,
          Driver = probie.Driver
        };
        return Ok(rv);
      }
    }
  }
}