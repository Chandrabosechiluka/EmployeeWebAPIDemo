using EmployeeWebAPIDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPIDemo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(MyContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public List<T> GetAll() => _table.ToList();

        public T GetById(Guid id) => _table.Find(id);

        public void Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }
    }
}
