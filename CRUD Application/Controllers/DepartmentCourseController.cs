using CRUD_Application.Interfaces;
using CRUD_Application.Models;
using CRUD_Application.Models.Data;
using CRUD_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class DepartmentCourseController : Controller
    {
        IRepo<Department> departmentRepo;
        IRepo<Course> courseRepo;
        public DepartmentCourseController(IRepo<Department> _departmentRepo,IRepo<Course> _courseRepo)
        {
            departmentRepo = _departmentRepo;
            courseRepo = _courseRepo;
        }
        public IActionResult ManageCourses(int? Id)
        { 
            IActionResult actionResult = BadRequest();
            if (Id != null)
            {
                Department department = departmentRepo.GetById(Id.Value);
                actionResult = NotFound();
                if (department != null)
                {
                    List<Course> coursesNotInDept = courseRepo.GetAll().Except(department.Courses).ToList();
                    var model = new DepartmentCoursesNotInDeptViewModel(department, coursesNotInDept);
                    actionResult = View(model);
                }
            }
            return actionResult;
        }
        [HttpPost]
        public IActionResult ManageCourses(int? Id,List<int> coursesToRemove , List<int> coursesToAdd)
        {
            IActionResult actionResult = BadRequest();
            if (Id != null)
            {
                Department department = departmentRepo.GetById(Id.Value);
                actionResult = NotFound();
                if (department != null)
                {
                    Course course;
                    foreach (int id in coursesToRemove)
                    {
                        course = courseRepo.GetById(id);
                        department.Courses.Remove(course);
                    }
                    foreach (int id in coursesToAdd)
                    {
                        course = courseRepo.GetById(id);
                        department.Courses.Add(course);
                    }
                    courseRepo.Save();
                    actionResult = RedirectToAction("Index","Department");
                }

            }
            return actionResult;
        }
    }
}
