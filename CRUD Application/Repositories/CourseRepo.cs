using CRUD_Application.Models;
using CRUD_Application.Models.Data;

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

        public Course GetById(int id)
        {
            return dbContext.Courses.SingleOrDefault(d => d.Id == id)!;
        }

        public int Update(Course entity)
        {
            dbContext.Courses.Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
