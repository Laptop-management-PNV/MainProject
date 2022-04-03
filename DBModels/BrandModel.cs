using DBModels.Init;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class BrandModel : Model
    {
        public List<brand> getBrandList()
        {
            return context.Database.SqlQuery<brand>("SELECT * FROM brands").ToList();
        }
        public brand getBrandById(int id)
        {
            object[] parameters =
            {
                new SqlParameter("@id", id)
            };
            return context.Database.SqlQuery<brand>("SP_GetBrandById @id", parameters).SingleOrDefault();
        }
    }
}
