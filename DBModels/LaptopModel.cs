using DBModels.Init;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class LaptopModel : Model
    {
        public LaptopModel() : base() { }
        public List<laptop> getLaptopList()
        {
            return context.Database.SqlQuery<laptop>("SELECT * FROM laptops ORDER BY loan_status DESC ").ToList();
        }
        public List<laptop> getFreeLaptopList()
        {
            return context.Database.SqlQuery<laptop>("SELECT * FROM laptops WHERE loan_status = 0").ToList();
        }
        public laptop getLaptopById(string id)
        {
            object[] parameter = { 
                new SqlParameter("@id", id)
            };
            return context.Database.SqlQuery<laptop>("SP_GetLaptopById @id", parameter).SingleOrDefault();
        }
        public void Create(laptop laptop)
        {
            object[] parameters =
            {
                new SqlParameter("@id", laptop.id),
                new SqlParameter("@brandId", laptop.brand_id),
                new SqlParameter("@name", laptop.name),
                new SqlParameter("@img", laptop.img)
            };
            context.Database.ExecuteSqlCommand("SP_CreateLaptop @id, @brandId, @name, @img", parameters);
        }
        public void Update(laptop laptop)
        {
            object[] parameters =
            {
                new SqlParameter("@id", laptop.id),
                new SqlParameter("@brandId", laptop.brand_id),
                new SqlParameter("@name", laptop.name),
                new SqlParameter("@img", laptop.img)
            };
            context.Database.ExecuteSqlCommand("SP_UpdateLaptop @id, @brandId, @name, @img", parameters);
        }
        public void Delete(string id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            context.Database.ExecuteSqlCommand("SP_DeleteLaptop @id", parameter);
        }
        public void updateLoanStatus(string id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            context.Database.ExecuteSqlCommand("SP_UpdateLaptopLoanStatus @id", parameter);
        }
    }
}
