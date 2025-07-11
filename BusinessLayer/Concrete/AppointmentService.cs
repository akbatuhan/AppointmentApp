using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentDal _appointmentDal;

        public AppointmentService(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public bool AppointmentControl(Appointment appo)
        {
            return _appointmentDal.AppointmentControl(appo);
        }

        public void Delete(Appointment item)
        {
            _appointmentDal.Delete(item);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentDal.GetAll();
        }

        public Appointment GetbyId(int id)
        {
            return _appointmentDal.GetbyId(id);
        }

        

        public void Insert(Appointment item)
        {
            _appointmentDal.Insert(item);
        }

        public void Update(Appointment item)
        {
            _appointmentDal.Update(item);
        }
    }
}
