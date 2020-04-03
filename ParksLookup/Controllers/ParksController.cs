using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParksLookup.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private ParksLookupContext _db;

    public ParksController(ParksLookupContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get(string management, string name, string location)
    {
      var query = _db.Parks.AsQueryable();
      if (management != null)
      {
        query = query.Where(entry => entry.Management == management);
      }
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }
      return query.ToList();
    }

     [HttpPost]
     public void Post([FromBody] Park park)
     {
       _db.Parks.Add(park);
       _db.SaveChanges();
     }

     [HttpGet("{id}")]
     public ActionResult<Park> GetAction(int id)
     {
       return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
     }

     [HttpPut("{id}")]
     public void Put(int id, [FromBody] Park park)
     {
       park.ParkId = id;
       _db.Entry(park).State = EntityState.Modified;
       _db.SaveChanges();
     }

     [HttpDelete("{id}")]
     public void Delete(int id)
     {
       var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
       _db.Parks.Remove(parkToDelete);
       _db.SaveChanges();
     }
  }
}