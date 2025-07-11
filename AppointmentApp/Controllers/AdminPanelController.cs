using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminPanelController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        //[Authorize]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");



            return View();
        }

        public IActionResult GetAdmins()
        {
            string? condition;
            condition = HttpContext.Session.GetString("Layout");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.BranchName = HttpContext.Session.GetString("DoctorBranch");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");


            if (!string.IsNullOrEmpty(condition))
            {
                ViewData["Condition"] = condition;

            }

            var values = _adminService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            return View();

        }



        [HttpPost]
        public IActionResult AddAdmin(Admin a)
        {
            if (ModelState.IsValid)
            {
                a.Password = PasswordHasher.HashPassword(a.Password);
                a.ConfirmPassword = PasswordHasher.HashPassword(a.ConfirmPassword);
                _adminService.Insert(a);
                return RedirectToAction("GetAdmins");
            }

            else { return View(); }

        }
    }
}
