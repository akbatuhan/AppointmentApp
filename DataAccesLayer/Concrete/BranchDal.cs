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
    public class BranchDal : GenericRepository<Branch>, IBranchDal
    {
        public List<Doctor> GetDoctorsByBranch(int id)
        {
            using (var c = new Contextt())
            {
                return c.Doctors
            .Where(x => x.BranchId == id)
            .ToList();
            }
        }
    }
}
