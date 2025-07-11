using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class Appointments : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public Appointments(IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            var values =_appointmentService.GetAll();
            return View(values);
        }

        public IActionResult DeleteAppointment(int id)
        {
            var value = _appointmentService.GetbyId(id);
            _appointmentService.Delete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AdminAddAppointment()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            return View();

        }



        [HttpPost]
        public IActionResult AdminAddAppointment(Appointment ap)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.Insert(ap);
                return RedirectToAction("Index");
            }

            else { return View(); }

        }

        [HttpGet]
        public IActionResult AdminUpdateAppointment(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            var value = _appointmentService.GetbyId(id);
            return View(value);
            
        }

        [HttpPost]
        public IActionResult AdminUpdateAppointment(Appointment ap)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.Update(ap);
                return RedirectToAction("Index");
            }

            else { return View(); }

        }



        [HttpGet]
        public IActionResult CreateAppointment(int id)
        {
            ViewBag.doctorId = id;
            ViewBag.UserSurname = HttpContext.Session.GetString("Surname");
            var userName = HttpContext.Session.GetString("UserName");
            var userId= HttpContext.Session.GetInt32("UserId");
            ViewBag.UserName = userName;
            ViewBag.UserId = userId;



            DateTime today = DateTime.Today;
            List<DateTime> next7Days = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                next7Days.Add(today.AddDays(i));
            }

            ViewBag.Next7Days = next7Days;

            List<string> saatler = new List<string> { "09.00", "10.00", "11.00", "13.00", "14.00", "15.00", "16.00" };
            ViewBag.Saatler = saatler;



            var values=_doctorService.GetListWithDoctorId(id);
            


            return View(values);
        }



        [HttpPost]
        public IActionResult CreateAppointment(Appointment ap)
        {
            var value=_appointmentService.AppointmentControl(ap);

            if (!value)
            {
                _appointmentService.Insert(ap);
                return RedirectToAction("Index", "UserPanel");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Randevu alınamadı doktor seçilen tarih ve saatte müsait değil");
                var userName = HttpContext.Session.GetString("UserName");
                var userId = HttpContext.Session.GetInt32("UserId");
                ViewBag.UserName = userName;
                ViewBag.UserId = userId;



                DateTime today = DateTime.Today;
                List<DateTime> next7Days = new List<DateTime>();
                for (int i = 0; i < 7; i++)
                {
                    next7Days.Add(today.AddDays(i));
                }

                ViewBag.Next7Days = next7Days;

                List<string> saatler = new List<string> { "09.00", "10.00", "11.00", "13.00", "14.00", "15.00", "16.00" };
                ViewBag.Saatler = saatler;


                ViewBag.doctorId = ap.DoctorId;
                var values = _doctorService.GetListWithDoctorId(ap.DoctorId);

                return View(values);    

            }
        }
    }
}
