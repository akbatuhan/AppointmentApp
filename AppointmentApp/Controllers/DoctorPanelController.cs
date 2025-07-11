using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class DoctorPanelController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public DoctorPanelController(IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }


        public IActionResult Index()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.BranchName = HttpContext.Session.GetString("DoctorBranch");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            return View();
        }

        public IActionResult GetDoctorsAppointments(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.BranchName = HttpContext.Session.GetString("DoctorBranch");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            var values = _doctorService.GetListWithDoctorId(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateAppointment(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.BranchName = HttpContext.Session.GetString("DoctorBranch");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            var value = _appointmentService.GetbyId(id);
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateAppointment(Appointment ap)
        {
            if (ModelState.IsValid)
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                _appointmentService.Update(ap);
                return RedirectToAction("Index");
            }

            else { return View(); }
            
        }


    }
}
