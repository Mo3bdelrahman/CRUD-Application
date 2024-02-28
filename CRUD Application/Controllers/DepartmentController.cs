using CRUD_Application.Interfaces;
using CRUD_Application.Models;
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
        public IActionResult Details(int Id)
        {
            Department model = departmentRepo.GetById(Id);
            IActionResult actionResult = model != null ? View(model) : BadRequest();
            return actionResult;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department Department)
        {
            int res = departmentRepo.Add(Department);
            IActionResult actionResult = res > 0 ? RedirectToAction("Index") : RedirectToAction("Create");
            return actionResult;
        }

        public IActionResult Edit(int Id)
        {
            Department model = departmentRepo.GetById(Id);
            IActionResult actionResult = model != null ? View(model) : BadRequest();
            return actionResult;
        }
        [HttpPost]
        public IActionResult Edit(Department Department)
        {
            int res = departmentRepo.Update(Department);
            IActionResult actionResult = res > 0 ? RedirectToAction("Index") : RedirectToAction("Edit");
            return actionResult;
        }
        public IActionResult Delete(int Id)
        {
            int res = departmentRepo.DeleteById(Id);
            return RedirectToAction("Index");
        }
        public IActionResult Show(int Id)
        {
            Department model = departmentRepo.GetById(Id);
            IActionResult actionResult = model != null ? View(model) : BadRequest();
            return actionResult;
        }
    }
}
