using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            string? condition;

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");

            ViewData["Condition"] = "MyLayout";

            condition = HttpContext.Session.GetString("Layout");

            

            if (!string.IsNullOrEmpty(condition))
            {
                ViewData["Condition"] = condition;

            }
            var value=_doctorService.GetListWithBranch();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            string? condition;

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");

            ViewData["Condition"] = "MyLayout";

            condition = HttpContext.Session.GetString("Layout");

            if (!string.IsNullOrEmpty(condition))
            {
                ViewData["Condition"] = condition;

            }
            return View();  
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor t)
        {
            if (ModelState.IsValid)
            {

                t.Password = PasswordHasher.HashPassword(t.Password);
                t.ConfirmPassword = PasswordHasher.HashPassword(t.ConfirmPassword);
                _doctorService.Insert(t);
                return RedirectToAction("Index");
            }

            else { return View(); }
        }

        public IActionResult DeleteDoctor(int id) {


            var value = _doctorService.GetbyId(id);
            _doctorService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDoctor(int id)
        {
            string? condition;
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");

            ViewData["Condition"] = "MyLayout";

            condition = HttpContext.Session.GetString("Layout");

            if (!string.IsNullOrEmpty(condition))
            {
                ViewData["Condition"] = condition;

            }
            var value = _doctorService.GetbyId(id);
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateDoctor(Doctor t)
        {
            t.Password = PasswordHasher.HashPassword(t.Password);
            t.ConfirmPassword = PasswordHasher.HashPassword(t.ConfirmPassword);

            _doctorService.Update(t);
            return RedirectToAction("Index");
        }
    }
}
