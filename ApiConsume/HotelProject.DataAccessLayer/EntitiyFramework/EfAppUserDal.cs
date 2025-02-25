﻿using HotelProject.DataAccessLayer.Abstarct;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntitiyFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {

        }

        public int GetAppUserCount()
        {
            Context context=new Context();
            return context.Users.Count();
            
        }

        public List<AppUser> UserListWithWorkLocation()
        {
            Context context= new Context();     
            return context.Users.Include(x=>x.WorkLocation).ToList();
        }

        public List<AppUser> UserListWithWorkLocations()
        {
            Context context = new Context();
            var values= context.Users.Include(x => x.WorkLocation).ToList();
            return values;
        }
    }
}
