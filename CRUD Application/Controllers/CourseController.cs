using CRUD_Application.Interfaces;
using CRUD_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class CourseController : Controller
    {
        IRepo<Course> courseRepo;
        public CourseController(IRepo<Course> _courseRepo)
        {
            courseRepo = _courseRepo;
        }
        public IActionResult Index()
        {
            return View(courseRepo.GetAll());
        }
        public IActionResult Details(int Id)
        {
            Course model = courseRepo.GetById(Id);
            IActionResult actionResult = model != null ? View(model) : BadRequest();
            return actionResult;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course Course)
        {
            int res = courseRepo.Add(Course);
            IActionResult actionResult = res > 0 ? RedirectToAction("Index") : RedirectToAction("Create");
            return actionResult;
        }

        public IActionResult Edit(int Id)
        {
            Course model = courseRepo.GetById(Id);
            IActionResult actionResult = model != null ? View(model) : BadRequest();
            return actionResult;
        }
        [HttpPost]
        public IActionResult Edit(Course Course)
        {
            int res = courseRepo.Update(Course);
            IActionResult actionResult = res > 0 ? RedirectToAction("Index") : RedirectToAction("Edit");
            return actionResult;
        }
        public IActionResult Delete(int Id)
        {
            int res = courseRepo.DeleteById(Id);
            return RedirectToAction("Index");
        }
    }
}
