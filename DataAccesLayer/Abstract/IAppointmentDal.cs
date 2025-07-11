using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IAppointmentDal:IGeneric<Appointment>
    {
        bool AppointmentControl(Appointment appo);

       

    }
}
