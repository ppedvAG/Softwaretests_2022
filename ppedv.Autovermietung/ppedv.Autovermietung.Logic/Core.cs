using ppedv.Autovermietung.Model;

namespace ppedv.Autovermietung.Logic
{
    public class Core
    {


        public Auto GetFastedCar(DateTime date)
        {
            var con = new Data.EFCore.EfContext();
            
            throw new NotImplementedException();
        }

        public void AddVermietung(Auto auto, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auto> GetAllAvailableCars(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}