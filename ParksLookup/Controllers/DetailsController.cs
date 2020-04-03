using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;
using Microsoft.AspNetCore.Authorization;
using ParksLookup.Services;

namespace ParksLookup.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class DetailsController : ControllerBase
  {
    private ParksLookupContext _db;
    private IUserService _userService;

    public DetailsController(ParksLookupContext db, IUserService userService)
    {
      _db = db;
      _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Detail>> Get(string description, string address, int rating)
    {
      var query = _db.Details.AsQueryable();
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }
      if (address != null)
      {
        query = query.Where(entry => entry.Address == address);
      }
      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Detail detail)
    {
      _db.Details.Add(detail);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Detail> GetAction(int id)
    {
      return _db.Details.FirstOrDefault(entry => entry.DetailId == id);
    }

    [HttpPut("{id}")]
     public void Put(int id, [FromBody] Detail detail)
    {
      detail.DetailId = id;
      _db.Entry(detail).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var detailToDelete = _db.Details.FirstOrDefault(entry => entry.DetailId == id);
      _db.Details.Remove(detailToDelete);
      _db.SaveChanges();
    }
  }
}