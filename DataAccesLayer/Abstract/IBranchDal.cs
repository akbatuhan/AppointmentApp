using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IBranchDal:IGeneric<Branch>
    {
        List<Doctor> GetDoctorsByBranch(int id);
    }
}

