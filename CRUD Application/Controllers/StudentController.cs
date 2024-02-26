using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
