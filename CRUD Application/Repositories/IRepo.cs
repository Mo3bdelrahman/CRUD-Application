namespace CRUD_Application.Repositories
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        //List<T> GetAllWhere(Predicate<T> checker);
        T GetById(int id);
        int Add(T entity);
        int Update(T entity);
        int DeleteById(int id);
    }
}
