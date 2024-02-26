using CRUD_Application.Models;

namespace CRUD_Application.ViewModels
{
    public class StudentWithDepartmentsViewModel
    {
        public Student Student { get; set; }
        public List<Department> Departments { get; set; }
        public StudentWithDepartmentsViewModel(List<Department> departments)
        {
            Departments = departments;
        }
        public StudentWithDepartmentsViewModel(Student student,List<Department> departments)
        {
            Student = student;
            Departments = departments;
        }
    }
}
