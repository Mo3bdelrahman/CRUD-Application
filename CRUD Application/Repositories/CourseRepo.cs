using CRUD_Application.Interfaces;
using CRUD_Application.Models;
using CRUD_Application.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRUD_Application.Repositories
{
    public class CourseRepo : IRepo<Course>
    {
        ApplicationDbContext dbContext;
        public CourseRepo(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public int Add(Course entity)
        {
            dbContext.Courses.Add(entity);
            return dbContext.SaveChanges();
        }

        public int DeleteById(int id)
        {
            Course crs = GetById(id);
            crs.IsDeleted = true;
            return dbContext.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return dbContext.Courses.Where(s => s.IsDeleted == false).ToList();
        }

        public List<Course> GetAllWhere(Func<Course,bool> checker)
        {
            return dbContext.Courses.Where(s => s.IsDeleted == false).Where(checker).ToList();
        }

        public List<Course> GetAllWith()
        {
            return dbContext.Courses.Where(s => s.IsDeleted == false).Include(c=>c.StudentCourses).ThenInclude(sc => sc.Student).ToList();
            
        }

        public Course GetById(int id)
        {
            return dbContext.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).SingleOrDefault(c => c.Id == id)!;
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public int Update(Course entity)
        {
            dbContext.Courses.Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
