using ppedv.Autovermietung.Model;
using ppedv.Autovermietung.Model.Contracts;

namespace ppedv.Autovermietung.Logic
{
    public class Core
    {
        public IRepository Repository { get; init; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public Auto GetFastedCar(DateTime date)
        {
            return Repository.GetAll<Auto>().OrderBy(x => x.PS).FirstOrDefault();
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