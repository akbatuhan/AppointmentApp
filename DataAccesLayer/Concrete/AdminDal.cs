
using DataAccesLayer.Abstract;
using DataAccesLayer.Context;
using DataAccesLayer.Repository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class AdminDal : GenericRepository<Admin>, IAdminDal
    {
        public Admin LogByMail_Password(Admin p)
        {
            using (var c = new Contextt())
            {

                var admin = c.Admins
              .Where(x => x.Mail == p.Mail && x.Password == p.Password).FirstOrDefault();

             

                if (admin != null)
                {
                    return admin;
                }

                else
                {
                    return null;
                }

            }
        }
    }
}
