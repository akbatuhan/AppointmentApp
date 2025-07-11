using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class BranchesController : Controller
    {

        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public IActionResult Index()
        {
            string? condition; /*= TempData["Condition"] as string;*/

            ViewData["Condition"] = "MyLayout";

            condition=HttpContext.Session.GetString("Layout");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.BranchName = HttpContext.Session.GetString("DoctorBranch");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");

            if (!string.IsNullOrEmpty(condition))
            {
                ViewData["Condition"] = condition;
                
            }

            var values = _branchService.GetAll();
            return View(values);
        }

        
        public IActionResult GetDoctors(int id)
        {
            string? condition;

            ViewData["Condition"] = "MyLayout";

            condition = HttpContext.Session.GetString("Layout");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.BranchName = HttpContext.Session.GetString("DoctorBranch");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");




            if (!string.IsNullOrEmpty(condition))
            {
                ViewData["Condition"] = condition;
            }



            var values=_branchService.GetDoctorsByBranch(id);
            return View(values);
        }

        public IActionResult DeleteBranch(int id)
        {
            var value = _branchService.GetbyId(id);
            _branchService.Delete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddBranch()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");

            return View();
        }

        [HttpPost]
        public IActionResult AddBranch(Branch b)
        {
            if (ModelState.IsValid)
            {

               
                _branchService.Insert(b);
                return RedirectToAction("Index");
            }

            else { return View(); }
        }




    }
}
