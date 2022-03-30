using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels {
    public class AdminModel : Model
    {
        public AdminModel() : base() { }
        public bool Login(string adminName, string password)
        {
            object[] parameters =
            {
                new SqlParameter("@name", adminName),
                new SqlParameter("@password", password)
            };
            return context.Database.SqlQuery<int>("SP_LoginCheck @name, @password", parameters).SingleOrDefault() == 1;
        }
        public void Create(string adminName, string password)
        {
            object[] parameters =
            {
                new SqlParameter("@name", adminName),
                new SqlParameter("@password", password)
            };
            context.Database.ExecuteSqlCommand("SP_InsertAdmin @name, @password", parameters);
        }
    }
}
