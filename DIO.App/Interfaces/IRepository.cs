namespace DIO.App.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lists();
        T ReturnId(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}