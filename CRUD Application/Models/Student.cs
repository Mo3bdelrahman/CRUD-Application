namespace CRUD_Application.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted {  get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<StudentCourse> StudentCourses  { get; set; }

    }
}
