using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
