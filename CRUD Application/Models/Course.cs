namespace CRUD_Application.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Department> Departments { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
