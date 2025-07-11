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
    public class PatientDal : GenericRepository<Patient>, IPatientDal
    {
        public List<Appointment> GetListWithPatientId(int? id)
        {
            using (var c = new Contextt())
            {
                return c.Appointments.Where(x => x.PatientId == id).Include(x => x.Doctor).ToList();
            };
        }

        public Patient GetPatientwith_Mail_TC(Patient p)
        {
            using (var c = new Contextt())
            {

                var patient = c.Patients
              .Where(x => x.Mail == p.Mail && x.TC == p.TC).FirstOrDefault();

                if (patient != null)
                {
                    return patient;
                }

                else
                {
                    return null;
                }

            }

        }

        public Patient LogByMail_Password(Patient p)
        {
            using (var c = new Contextt())
            {

                var patient = c.Patients
              .Where(x => x.Mail == p.Mail && x.Password == p.Password).FirstOrDefault();
             
                if(patient!=null )
                {
                    return patient;
                }

                else
                {
                    return null;
                }

            }
        }
    }
}
