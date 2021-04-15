using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBank2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            List<User> resultusers;
            using (UsersDatabase db = new UsersDatabase())
            {
                resultusers = db.Users.ToList();
            }

            return resultusers;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            using (UsersDatabase db = new UsersDatabase())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        // POST api/values
        [HttpPost("Login")]

        public IActionResult Login([FromBody] LoginForm loginform)
        {
            using (UsersDatabase db = new UsersDatabase())
            {
                ClassLibrary1.User u = db.Users.FirstOrDefault(user => user.Name.Equals(loginform.UserName));
                if (u != null)
                {
                    if (u.Password.Equals(loginform.Password))
                    {
                        return Ok();
                    }
                }
            }

            return NotFound();
        }
    }
}
