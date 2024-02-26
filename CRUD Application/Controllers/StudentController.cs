using CRUD_Application.Models;
using CRUD_Application.Repositories;
using CRUD_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Controllers
{
    public class StudentController : Controller
    {
        IRepo<Student> studentRepo;
        IRepo<Department> departmentRepo;
        public StudentController(IRepo<Student> _studentRepo, IRepo<Department> _departmentRepo)
        {
            studentRepo = _studentRepo;
            departmentRepo = _departmentRepo;
        }
        public IActionResult Index()
        {
            return View(studentRepo.GetAll());
        }
        public IActionResult Create()
        {    
            var model = new StudentWithDepartmentsViewModel(departmentRepo.GetAll());
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Student Student)
        {
            int res = studentRepo.Add(Student);
            IActionResult actionResult = res !=0 ? RedirectToAction("Index") : RedirectToAction("Create");
            return actionResult;
        }
    }
}
