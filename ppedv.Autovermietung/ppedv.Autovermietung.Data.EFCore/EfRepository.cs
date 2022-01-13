using ppedv.Autovermietung.Model;
using ppedv.Autovermietung.Model.Contracts;

namespace ppedv.Autovermietung.Data.EFCore
{
    public class EfRepository : IRepository
    {
        EfContext _context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            _context.Add(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}
