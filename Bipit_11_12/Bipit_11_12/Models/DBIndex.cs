using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Bipit_11_12.Models
{
    public class DBIndex : DbContext
    {
        public DbSet<Res> Res { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TODO> TODO { get; set; }
        public bool Auth(string login, string pass)
        {
            var us = Users.FirstOrDefault(i => i.Name == login && i.Pass == pass);
            if (us != null)
            {
                HttpContext.Current.Items.Add("Login", us.Name);
                return true;
            }
            return false;
        }
        public bool LogOut()
        {
            HttpContext.Current.Items.Clear();
            return true;
        }
        public DBIndex() : base("DBContext")
        {
            Res = Set<Res>();
            Users = Set<Users>();
            TODO = Set<TODO>();
        }
        public List<object> UsersTable()
        {
            return GetTable(0);
        }
        public List<object> TODOTable()
        {
            return GetTable(1);
        }
        public List<object> ResTable()
        {
            return GetTable(2);
        }
        private List<object> GetTable(int index)
        {
            var sourse = new List<object>();
            Type type = typeof(object);
            switch (index)
            {
                case 0:
                    sourse = Users.AsEnumerable().Select(item => ((object)item)).ToList();
                    type = typeof(Users);
                    break;
                case 1:
                    sourse = TODO.AsEnumerable().Select(item => ((object)item)).ToList();
                    type = typeof(TODO);
                    break;
                case 2:
                    sourse = Res.AsEnumerable().Select(item => ((object)item)).ToList();
                    foreach (var s in sourse)
                    {
                        ((Res)s).User = Users.FirstOrDefault(i => i.ID == ((Res)s).ID_user);
                        ((Res)s).TODO = TODO.FirstOrDefault(i => i.ID == ((Res)s).ID_todo);
                    }
                    type = typeof(Res);
                    break;
            }

            return sourse;
        }
    }
}