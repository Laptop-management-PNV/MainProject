using DBModels.Init;

namespace DBModels
{
    public class Model
    {
        protected DBContext context;
        public Model()
        {
            context = new DBContext();
        }

    }
}