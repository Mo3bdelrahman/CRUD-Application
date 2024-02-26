using CRUD_Application.Models;
using CRUD_Application.Models.Data;

namespace CRUD_Application.Repositories
{
    public class DepartmentRepo : IRepo<Department>
    {
        ApplicationDbContext dbContext;

        public DepartmentRepo()
        {
            dbContext = new ApplicationDbContext();
        }
        public int Add(Department entity)
        {
            dbContext.Departments.Add(entity);
            return dbContext.SaveChanges();
        }

        public int DeleteById(int id)
        {
            Department dep = GetById(id);
            dep.IsDeleted = true;
            return dbContext.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return dbContext.Departments.Where(s => s.IsDeleted == false).ToList();
        }

        public Department GetById(int id)
        {
            return dbContext.Departments.SingleOrDefault(d => d.Id == id)!;
        }

        public int Update(Department entity)
        {
            dbContext.Departments.Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
