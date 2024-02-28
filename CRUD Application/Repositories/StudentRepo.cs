using CRUD_Application.Interfaces;
using CRUD_Application.Models;
using CRUD_Application.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Repositories
{
    public class StudentRepo : IRepo<Student>
    {
        ApplicationDbContext dbContext;

        public StudentRepo(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public int Add(Student entity)
        {
            dbContext.Students.Add(entity);
            return dbContext.SaveChanges();
        }

        public int DeleteById(int id)
        {
            Student dep = GetById(id);
            dep.IsDeleted = true;
            return dbContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return dbContext.Students.Where(s=>s.IsDeleted == false).ToList();
        }

        public List<Student> GetAllWhere(Func<Student, bool> checker)
        {
            return dbContext.Students.Where(s => s.IsDeleted == false).Where(checker).ToList();
        }

        public List<Student> GetAllWith()
        {
            return dbContext.Students.Where(s => s.IsDeleted == false).Include(s => s.Department).ToList();
        }

        public Student GetById(int id)
        {
            return dbContext.Students.SingleOrDefault(d => d.Id == id)!;
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public int Update(Student entity)
        {
            dbContext.Students.Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
