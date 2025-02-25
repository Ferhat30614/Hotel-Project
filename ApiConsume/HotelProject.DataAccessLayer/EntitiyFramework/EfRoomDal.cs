﻿using HotelProject.DataAccessLayer.Abstarct;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntitiyFramework
{
    public class EfRoomDal:GenericRepository<Room>,IRoomDal
    {
        public EfRoomDal(Context context):base(context)
        {
            
        }

        public int GetRoomCount()
        {
            Context context=new Context();
            return context.Rooms.Count();
        }
    }
}
