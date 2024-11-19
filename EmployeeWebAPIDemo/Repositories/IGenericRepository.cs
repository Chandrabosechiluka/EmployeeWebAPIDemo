namespace EmployeeWebAPIDemo.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(Guid id);
        public void Add(T entity);
    }
}
