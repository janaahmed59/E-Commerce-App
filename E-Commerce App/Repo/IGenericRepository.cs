namespace E_Commerce_App.Repo
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);

        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
