using CRUD_Application.Models;
using CRUD_Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class DepartmentController : Controller
    {
        IRepo<Department> departmentRepo;
        public DepartmentController(IRepo<Department> _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }
        public IActionResult Index()
        {
            return View(departmentRepo.GetAll());
        }
    }
}
