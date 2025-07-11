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
    public class BranchService : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchService(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public void Delete(Branch item)
        {
            _branchDal.Delete(item);
        }

        public List<Branch> GetAll()
        {
            return _branchDal.GetAll();
        }

        public Branch GetbyId(int id)
        {
            return _branchDal.GetbyId(id);
        }

        public List<Doctor> GetDoctorsByBranch(int id)
        {
            return _branchDal.GetDoctorsByBranch(id);
        }

        public void Insert(Branch item)
        {
            _branchDal.Insert(item);
        }

        public void Update(Branch item)
        {
            _branchDal.Update(item);
        }
    }
}
