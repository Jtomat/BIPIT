using Bipit_11_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bipit_11_12.Controllers
{
    public class ValuesController : ApiController
    {
        DBIndex connect = new DBIndex();

        #region Geters
        [HttpGet]
        public IEnumerable<Res> GetReses()
        {
            return connect.Res;
        }
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return connect.Users;
        }
        [HttpGet]
        public IEnumerable<TODO> GetTODOs()
        {
            return connect.TODO;
        }
        [HttpGet]
        public Res GetResByID(int id)
        {
            return connect.Res.FirstOrDefault(i => i.ID == id);
        }
        [HttpGet]
        public TODO GetTODOByID(int id)
        {
            return connect.TODO.FirstOrDefault(i => i.ID == id);
        }
        [HttpGet]
        public Users GetUserByID(int id)
        {
            return connect.Users.FirstOrDefault(i => i.ID == id);
        }
        #endregion

        #region Adders
        [HttpPost]
        public void AddUser([FromBody] Users value)
        {
            connect.Users.Add(value);
            connect.SaveChanges();
        }

        [HttpPost]
        public void AddRes([FromBody] Res value)
        {
            connect.Res.Add(value);
            connect.SaveChanges();
        }

        [HttpPost]
        public void AddTODO([FromBody] TODO value)
        {
            connect.TODO.Add(value);
            connect.SaveChanges();
        }
        #endregion
        #region Deleters
        [HttpDelete]
        public void DeleteUserByID(int id)
        {
            connect.Users.Remove
                (connect.Users.FirstOrDefault(i=>i.ID==id));
            connect.SaveChanges();
        }
        [HttpDelete]
        public void DeleteResByID(int id)
        {
            connect.Res.Remove
                (connect.Res.FirstOrDefault(i => i.ID == id));
            connect.SaveChanges();
        }
        [HttpDelete]
        public void DeleteTODOByID(int id)
        {
            connect.TODO.Remove
                (connect.TODO.FirstOrDefault(i => i.ID == id));
            connect.SaveChanges();
        }
        #endregion
    }
}
