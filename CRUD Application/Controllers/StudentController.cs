using CRUD_Application.Interfaces;
using CRUD_Application.Models;
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
            return View(studentRepo.GetAllWith());
        }
        public IActionResult Create()
        {    
            var model = new StudentWithDepartmentsViewModel(departmentRepo.GetAllWith());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student Student, IFormFile image)
        {
            if (Student != null)
            {
                studentRepo.Add(Student);

                if (image != null)
                {
                    string fileexe = image.FileName.Split('.').Last();
                    string img = $"{Student.Name}_{Student.Id}.{fileexe}";
                    using (var fs = new FileStream($"wwwroot/Images/{img}", FileMode.Create))
                    {
                        await image.CopyToAsync(fs);
                    }
                    Student.ImagePath = img;
                }
                studentRepo.Update(Student);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        public IActionResult Details(int Id)
        {
            Student model = studentRepo.GetById(Id);
            IActionResult actionResult = model != null ? View(model) : BadRequest();
            return actionResult;
        }
        public IActionResult Edit(int Id)
        {
            IActionResult actionResult = BadRequest();
            Student student = studentRepo.GetById(Id);
            if(student != null)
            {
                var model = new StudentWithDepartmentsViewModel(student, departmentRepo.GetAllWith());
                actionResult = View(model);
            }
            return actionResult;
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student Student,int Id, IFormFile image)
        {
            if (image != null)
            {
                string fileexe = image.FileName.Split('.').Last();
                string img = $"{Student.Name}_{Student.Id}.{fileexe}";
                using (var fs = new FileStream($"wwwroot/Images/{img}", FileMode.Create))
                {
                    await image.CopyToAsync(fs);
                }
                Student.ImagePath = img;
            }
            Student.Id = Id;
            int res = studentRepo.Update(Student);
            IActionResult actionResult = res>0? RedirectToAction("Index") : RedirectToAction("Edit");
            return actionResult;
        }
        public IActionResult Delete(int Id)
        {
            int res = studentRepo.DeleteById(Id);
            return RedirectToAction("Index");
        }
    }
}
