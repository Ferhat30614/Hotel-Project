using HotelProject.DataAccessLayer.Abstarct;
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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {

        public EfStaffDal(Context context) : base(context)
        {

        }

        public int GetStaffCount()
        {
            Context context=new Context();
            var values = context.Staffs.Count();
            return values;
        }

        public List<Staff> Last4Staff()
        {
            Context context = new Context();        
            var values = context.Staffs.OrderByDescending(x=>x.StaffID).Take(4).ToList();
            return values;  
        }
    }
}


