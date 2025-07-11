using DataAccesLayer.Abstract;
using DataAccesLayer.Context;
using DataAccesLayer.Repository;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class DoctorDal : GenericRepository<Doctor>, IDoctorDal
    {
        public List<Doctor> GetListWithBranch()
        {
            using (var c = new Contextt())
            {
                return c.Doctors.Include(x => x.Branch).ToList();
            }
        }

        public List<Appointment> GetListWithDoctorId(int id)
        {
            using (var c = new Contextt())
            {
                return c.Appointments.Where(x => x.DoctorId == id).Include(x => x.Patient).ToList();
            };
        }

        public Doctor LogByMail_Password(Doctor D)
        {
            using (var c = new Contextt())
            {

                var doctor = c.Doctors
              .Where(x => x.Mail == D.Mail && x.Password == D.Password).Include(x => x.Branch).FirstOrDefault();



                if (doctor != null)
                {
                    return doctor;
                }

                else
                {
                    return null;
                }
            }
        }
    }

    

}
