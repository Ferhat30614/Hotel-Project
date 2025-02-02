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
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {

        public EfContactDal(Context context) : base(context)
        {

        }





    }
}
