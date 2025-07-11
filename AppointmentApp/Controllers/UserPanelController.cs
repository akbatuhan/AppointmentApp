using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly IPatientService _patientService;

        public UserPanelController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            return View();
        }

       


        public IActionResult GetPatientAppointments()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");


            var values = _patientService.GetListWithPatientId(userId);
            return View(values);
        }

        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear(); 

            return RedirectToAction("Index", "MainPage"); 
        }
    }
}
