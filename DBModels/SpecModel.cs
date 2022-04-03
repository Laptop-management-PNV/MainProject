using DBModels.Init;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class SpecModel : Model
    {
        public SpecModel() : base() { }

        public spec getSpecById(string id)
        {
            object[] parameter =
            {
                new SqlParameter("@id", id)
            };
            return context.Database.SqlQuery<spec>("SP_GetSpecById @id", parameter).SingleOrDefault();
        }
        public void Create(spec spec)
        {
            object[] parameters =
            {
                new SqlParameter("@laptopId", spec.laptop_id),
                new SqlParameter("@memory", spec.memory),
                new SqlParameter("@hardDrive", spec.hard_drive),
                new SqlParameter("@graphicCard", spec.graphic_card),
                new SqlParameter("@resolution", spec.resolution)
            };
            context.Database.ExecuteSqlCommand("SP_CreateSpec @laptopId, @memory, @hardDrive, @graphicCard, @resolution", parameters);
        }
        public void Update(spec spec)
        {
            object[] parameters =
            {
                new SqlParameter("@laptopId", spec.laptop_id),
                new SqlParameter("@memory", spec.memory),
                new SqlParameter("@hardDrive", spec.hard_drive),
                new SqlParameter("@graphicCard", spec.graphic_card),
                new SqlParameter("@resolution", spec.resolution)
            };
            context.Database.ExecuteSqlCommand("SP_UpdateSpec @laptopId, @memory, @hardDrive, @graphicCard, @resolution", parameters);
        }
    }
}
