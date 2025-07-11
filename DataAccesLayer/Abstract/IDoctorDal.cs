using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IDoctorDal:IGeneric<Doctor>
    {
        List<Doctor> GetListWithBranch();

        List<Appointment> GetListWithDoctorId(int id);

        Doctor LogByMail_Password(Doctor D);

    }
}
