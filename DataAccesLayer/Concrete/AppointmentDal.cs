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
    public class AppointmentDal : GenericRepository<Appointment>, IAppointmentDal
    {
        public bool AppointmentControl(Appointment appo)
        {
            using (var c = new Contextt())
            {

                var appointment = c.Appointments
              .Where(x => x.Date == appo.Date && x.Hour == appo.Hour && x.DoctorId==appo.DoctorId).FirstOrDefault();

                if (appointment != null)
                {
                    return true;
                }

                else
                {
                    return false;
                }

            }
        }

       

        
    }
}
