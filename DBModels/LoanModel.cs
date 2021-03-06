using DBModels.Init;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class LoanModel : Model
    {
        public List<loan> getLoanHistory()
        {
            return context.Database.SqlQuery<loan>("SELECT * FROM loan ORDER BY loaned_date DESC, returned_date ASC").ToList();
        }
        public loan getLoanDetailByStdId(string id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            return context.Database.SqlQuery<loan>("SP_GetLoanDetailByStdId @id", parameter).SingleOrDefault();
        }
        public loan getLoanDetailById(int id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            return context.Database.SqlQuery<loan>("SP_GetLoanDetailById @id", parameter).SingleOrDefault();
        }
        public void createLoanDetail(loan loan)
        {
            object[] parameters =
            {
                new SqlParameter("@stdId", loan.student_id),
                new SqlParameter("@laptopId", loan.laptop_id),
                new SqlParameter("@loanedDate", loan.loaned_date),
                new SqlParameter("@adminName", loan.admin_name)
            };
            context.Database.ExecuteSqlCommand("SP_CreateLoanDetail @stdId, @laptopId, @loanedDate, @adminName", parameters);
        }
        public void updateReturnedDate(loan loan)
        {
            object[] parameters =
            {
                new SqlParameter("@id", loan.student_id),
                new SqlParameter("@ReturnedDate", loan.returned_date)
            };
            context.Database.ExecuteSqlCommand("SP_UpdateReturnedDate @id, @returnedDate", parameters);
        }
    }
}
