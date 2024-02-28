using CRUD_Application.Interfaces;
using CRUD_Application.Models;
using CRUD_Application.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Repositories
{
    public class DepartmentRepo : IRepo<Department>
    {
        ApplicationDbContext dbContext;

        public DepartmentRepo(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
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

        public List<Department> GetAllWhere(Func<Department, bool> checker)
        {
            return dbContext.Departments.Where(d => d.IsDeleted == false).Where(checker).ToList();
        }

        public List<Department> GetAllWith()
        {
            return dbContext.Departments.Where(d => d.IsDeleted == false).Include(d => d.Courses).ToList();
                
        }

        public Department GetById(int id)
        {
            return dbContext.Departments.Include(d => d.Courses).SingleOrDefault(d => d.Id == id)!;
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public int Update(Department entity)
        {
            dbContext.Departments.Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
