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
    public class AdminService : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminService(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Delete(Admin item)
        {
            _adminDal.Delete(item);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetbyId(int id)
        {
            return _adminDal.GetbyId(id);
        }

        public void Insert(Admin item)
        {
           _adminDal.Insert(item);
        }

        public Admin LogByMail_Password(Admin p)
        {
            return _adminDal.LogByMail_Password(p);
        }

        public void Update(Admin item)
        {
           _adminDal.Delete(item);
        }
    }
}
