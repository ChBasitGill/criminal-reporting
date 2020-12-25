using criminal.reporting.database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace criminal.reporting.repository
{
    public class IRepository<T> : IRepository<T> where T : class
    {
        private CriminalDbContext _context = null;
        private DbSet<T> table = null;
        public IRepository()
        {
            this._context = new CriminalDbContext();
            table = _context.Set<T>();
        }
        public IRepository(CriminalDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();

        }
        public T GetById(int id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
