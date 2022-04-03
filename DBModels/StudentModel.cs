using DBModels.Init;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class StudentModel : Model
    {
        public List<student> getStudentList()
        {
            return context.Database.SqlQuery<student>("SELECT * FROM students ORDER BY loan_status DESC").ToList();
        }
        public student getStudentById(string id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            return context.Database.SqlQuery<student>("SP_GetStudentById @id", parameter).SingleOrDefault();
        }
        public void updateLoanStatus(string id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            context.Database.ExecuteSqlCommand("SP_UpdateStudentLoanStatus @id", parameter);
        }
    }
}
