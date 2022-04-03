using DBModels.Init;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels {
    public class AdminModel : Model
    {
        public bool Login(string adminName, string password)
        {
            object[] parameters =
            {
                new SqlParameter("@name", adminName),
                new SqlParameter("@password", password)
            };
            return context.Database.SqlQuery<int>("SP_LoginCheck @name, @password", parameters).SingleOrDefault() == 1;
        }
        public bool isDuplicated(string adminName)
        {
            return context.Database.SqlQuery<int>($"SELECT count(*) FROM admins WHERE name = '{adminName}'").SingleOrDefault() == 1;
        }
        public admin getAdminByName(string adminName)
        {
            object[] parameters =
            {
                new SqlParameter("@name", adminName)
            };
            return context.Database.SqlQuery<admin>("SP_GetAdmin @name", parameters).SingleOrDefault();
        }
        public List<admin> getAdminList(string adminName)
        {
            return context.Database.SqlQuery<admin>($"SELECT * FROM admins WHERE name != '{adminName}' ORDER BY permission ASC, active DESC").ToList();
        }
        public void Create(string adminName, string password, string permission)
        {
            object[] parameters =
            {
                new SqlParameter("@name", adminName),
                new SqlParameter("@password", password),
                new SqlParameter("@permission", permission)
            };
            context.Database.ExecuteSqlCommand("SP_CreateAdmin @name, @password, @permission", parameters);
        }
        public void Delete(string adminName)
        {

            object[] parameters =
            {
                new SqlParameter("@name", adminName),
            };
            context.Database.ExecuteSqlCommand("SP_DeleteAdmin @name", parameters);
        }
        public void Active(string adminName)
        {

            object[] parameters =
            {
                new SqlParameter("@name", adminName),
            };
            context.Database.ExecuteSqlCommand("SP_ActiveAdmin @name", parameters);
        }
    }
}
