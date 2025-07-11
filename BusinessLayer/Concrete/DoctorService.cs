using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;

        public DoctorService(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public void Delete(Doctor item)
        {
            _doctorDal.Delete(item);
        }

        public List<Doctor> GetAll()
        {
            return _doctorDal.GetAll();
        }

        public Doctor GetbyId(int id)
        {
           return _doctorDal.GetbyId(id);
        }

        public List<Doctor> GetListWithBranch()
        {
            return _doctorDal.GetListWithBranch();
        }

        public List<Appointment> GetListWithDoctorId(int id)
        {
            return _doctorDal.GetListWithDoctorId(id);
        }

        public void Insert(Doctor item)
        {
            _doctorDal.Insert(item);
        }

        public Doctor LogByMail_Password(Doctor D)
        {
            return _doctorDal.LogByMail_Password(D);
        }

        public void Update(Doctor item)
        {
            _doctorDal.Update(item);
        }
    }
}
