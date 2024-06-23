using Microsoft.AspNetCore.Mvc;
using mvcEmployee.Models;
using mvcEmployee.Service;

namespace mvcEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employees payload)
        {
            if(ModelState.IsValid)
            {
                _service.CREATEEMPLOYEE(payload);
                return RedirectToAction(nameof(GetALL));
            }
            return View(payload);
            
        }

        public IActionResult GetALL()
        {
            IEnumerable <Employees> employer = _service.GetAllEmployee();
            return View(employer);
        }
    }
}
