﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService: IGenericService<Admin>
    {
        Admin LogByMail_Password(Admin p);
    }
}
