using System.Data.Common;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zamastrov.DataObjects;

namespace Zamastrov.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
   

    private readonly ILogger<User> _logger;

    public UserController(ILogger<User> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetUser")]
    //public DbSet<User> Get()
    //{
    //    za_masterov_devContext context = new za_masterov_devContext();
    //    return context.User;
    //}

    [HttpGet(Name = "GetUser")]
    public async Task<List<CityRef>> Get()
    {
        List<User> userList = new List<User>();
        za_masterov_devContext db = new za_masterov_devContext();
        var usr = db.CityRef.FromSqlRaw("SELECT * FROM `city_ref`").ToList();
        //var usr = db.Client.FromSqlRaw("SELECT * FROM client").ToList();
        // var query = from u in db.CityRef select u;
        // var usr = query.FirstOrDefault<CityRef>();
         return usr;
    }
}