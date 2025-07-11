using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            var values=_patientService.GetAll();
            return View(values);
        }

        public IActionResult DeletePatient(int id)
        {
            var value = _patientService.GetbyId(id);
            _patientService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            return View();

        }



        [HttpPost]
        public IActionResult AddPatient(Patient p)
        {
            if (ModelState.IsValid)
            {
                _patientService.Insert(p);
                return RedirectToAction("Index");
            }

            else { return View(); }

        }

       
    }
}
