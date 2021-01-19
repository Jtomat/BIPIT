using Bipit_11_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bipit_11_12.Controllers
{
    public class TODOController : ApiController
    {
        DBIndex connect = new DBIndex();

        [HttpGet]
        public IEnumerable<TODO> GetTODOs()
        {
            return connect.TODO;
        }

        [HttpGet]
        public TODO GetTODOByID(int id)
        {
            return connect.TODO.FirstOrDefault(i => i.ID == id);
        }

        [HttpPost]
        public void AddTODO([FromBody] TODO value)
        {
            connect.TODO.Add(value);
            connect.SaveChanges();
        }

        [HttpDelete]
        public void DeleteTODOByID(int id)
        {
            connect.TODO.Remove
                (connect.TODO.FirstOrDefault(i => i.ID == id));
            connect.SaveChanges();
        }
    }
}
