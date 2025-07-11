using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPatientService:IGenericService<Patient>
    {
          Patient LogByMail_Password(Patient p);

           List<Appointment> GetListWithPatientId(int? id);

           Patient GetPatientwith_Mail_TC(Patient p);
    }
}
