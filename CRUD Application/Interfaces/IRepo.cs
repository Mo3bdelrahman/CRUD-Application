namespace CRUD_Application.Interfaces
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        List<T> GetAllWhere(Func<T,bool> checker);
        List<T> GetAllWith();
        T GetById(int id);
        int Add(T entity);
        int Update(T entity);
        int DeleteById(int id);
        int Save();
    }
}
