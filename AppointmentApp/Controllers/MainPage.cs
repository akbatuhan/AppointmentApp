using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Entities;

using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class MainPage : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;

        public MainPage(IPatientService patientService, IAdminService adminService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _adminService = adminService;
            _doctorService = doctorService;
        }

        

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Register(Patient t)
        {
            if(ModelState.IsValid)
            {

                t.Password = PasswordHasher.HashPassword(t.Password);
                t.ConfirmPassword = PasswordHasher.HashPassword(t.ConfirmPassword);
                t.TC = PasswordHasher.HashPassword(t.TC);

                _patientService.Insert(t);
                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Patient t)
        {
            t.Password = PasswordHasher.HashPassword(t.Password);
            var value=_patientService.LogByMail_Password(t);

            if (value!=null)
            {
                string Layout_option = "PatientDashboard";
                HttpContext.Session.SetString("UserName", value.Name);
                HttpContext.Session.SetString("Surname", value.Surname);
                HttpContext.Session.SetInt32("UserId", value.Id);
                HttpContext.Session.SetString("Layout",Layout_option);

                return RedirectToAction("Index","UserPanel");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Yanlış e-posta veya şifre.");
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult AdminLogIn()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogIn(Admin t)
        {
            t.Password = PasswordHasher.HashPassword(t.Password);
            var value = _adminService.LogByMail_Password(t);

            if (value != null)
            {
                string Layout_option = "AdminDashboard";
                HttpContext.Session.SetString("UserName", value.Name);
                HttpContext.Session.SetString("Surname", value.Surname);
                HttpContext.Session.SetInt32("UserId", value.Id);
                HttpContext.Session.SetString("Layout", Layout_option);

                return RedirectToAction("Index", "AdminPanel");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Yanlış e-posta veya şifre.");
                return View();
            }

        }

        [HttpGet]
        public IActionResult DoctorLogIn()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult DoctorLogIn(Doctor D)
        {
            D.Password = PasswordHasher.HashPassword(D.Password);
            var value = _doctorService.LogByMail_Password(D);

            if (value != null)
            {
                string Layout_option = "DoctorDashboard";
                HttpContext.Session.SetString("UserName", value.Name);
                HttpContext.Session.SetInt32("UserId", value.Id);
                HttpContext.Session.SetString("Layout", Layout_option);
                HttpContext.Session.SetString("DoctorBranch", value.Branch.Name);
                HttpContext.Session.SetString("Surname", value.Surname);

                return RedirectToAction("Index", "DoctorPanel");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Yanlış e-posta veya şifre.");
                return View();
            }

        }

        [HttpGet]
        public IActionResult ChangePasswordControl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePasswordControl(Patient p)
        {
            p.TC = PasswordHasher.HashPassword(p.TC);
            var value = _patientService.GetPatientwith_Mail_TC(p);

            if (value != null)
            {
                HttpContext.Session.SetInt32("UserId", value.Id);
                return RedirectToAction("ChangePassword", new { id = value.Id });
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Yanlış e-posta veya TC.");
                return View();
            }


           
        }

        [HttpGet]
        public IActionResult ChangePassword(int id)
        {
            var value = _patientService.GetbyId(id);
            value.Password = null;
            value.ConfirmPassword = null;
            return View(value);
            
        }

        [HttpPost]
        public IActionResult ChangePassword(Patient p)
        {
            p.Password = PasswordHasher.HashPassword(p.Password);
            p.ConfirmPassword = PasswordHasher.HashPassword(p.ConfirmPassword);
            _patientService.Update(p);
            return RedirectToAction("Index");

        }











    }
}
