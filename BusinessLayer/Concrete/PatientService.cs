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
    public class PatientService : IPatientService
    {

        private readonly IPatientDal _patientdal;

        public PatientService(IPatientDal patientdal)
        {
            _patientdal = patientdal;
        }

        public void Delete(Patient item)
        {
            _patientdal.Delete(item);
        }

        public List<Patient> GetAll()
        {
            return _patientdal.GetAll();
        }

        public Patient GetbyId(int id)
        {
            return _patientdal.GetbyId(id);
        }

        public List<Appointment> GetListWithPatientId(int? id)
        {
            return _patientdal.GetListWithPatientId(id);
        }

        public Patient GetPatientwith_Mail_TC(Patient p)
        {
            return _patientdal.GetPatientwith_Mail_TC(p);
        }

        public void Insert(Patient item)
        {
            _patientdal.Insert(item);
        }

        public Patient LogByMail_Password(Patient p)
        {
            return _patientdal.LogByMail_Password(p);
        }

        public void Update(Patient item)
        {
            _patientdal.Update(item);
        }
    }
}
