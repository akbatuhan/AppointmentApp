﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IAdminDal:IGeneric<Admin>
    {
        Admin LogByMail_Password(Admin p);

    }
}
