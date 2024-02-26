namespace CRUD_Application.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public List<Student> Students { get; set; } 
        public List<Course> Courses { get; set; }
    }
}
