using CRUD_Application.Models;

namespace CRUD_Application.ViewModels
{
    public class DepartmentCoursesNotInDeptViewModel
    {
        public Department Department { get; set; }
        public List<Course> coursesNotInDept { get; set; }

        public DepartmentCoursesNotInDeptViewModel(Department _department, List<Course> _coursesNotInDept)
        {
            Department = _department;
            coursesNotInDept = _coursesNotInDept;
        }
    }
}
