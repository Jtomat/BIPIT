using Bipit_11_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bipit_11_12.Controllers
{
    public class ResController : ApiController
    {
        DBIndex connect = new DBIndex();

        [HttpGet]
        public IEnumerable<Res> GetReses()
        {
            return connect.Res;
        }

        [HttpGet]
        public Res GetResByID(int id)
        {
            var res = connect.Res.FirstOrDefault(i => i.ID == id);
            res.User = connect.Users.FirstOrDefault(i => i.ID == res.ID_user);
            res.TODO = connect.TODO.FirstOrDefault(i => i.ID == res.ID_todo);
            return res;
        }

        [HttpPost]
        public void AddRes([FromBody] Res value)
        {
            connect.Res.Add(value);
            connect.SaveChanges();
        }

        [HttpDelete]
        public void DeleteResByID(int id)
        {
            connect.Res.Remove
                (connect.Res.FirstOrDefault(i => i.ID == id));
            connect.SaveChanges();
        }
    }
}
