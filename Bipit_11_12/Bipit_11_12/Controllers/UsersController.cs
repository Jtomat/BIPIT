using Bipit_11_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bipit_11_12.Controllers
{
    public class UsersController : ApiController
    {
        DBIndex connect = new DBIndex();

        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return connect.Users;
        }

        [HttpGet]
        public Users GetUserByID(int id)
        {
            return connect.Users.FirstOrDefault(i => i.ID == id);
        }

        [HttpPost]
        public void AddUser([FromBody] Users value)
        {
            connect.Users.Add(value);
            connect.SaveChanges();
        }

        [HttpDelete]
        public void DeleteUserByID(int id)
        {
            connect.Users.Remove
                (connect.Users.FirstOrDefault(i => i.ID == id));
            connect.SaveChanges();
        }
    }
}
