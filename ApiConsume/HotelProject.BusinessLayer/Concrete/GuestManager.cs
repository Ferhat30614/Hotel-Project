using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstarct;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }
        public void TDelete(Guest t)
        {
            _guestDal.Delete(t);    
        }

        public Guest TGetById(int id)
        {
            return _guestDal.GetById(id);   
        }

        public List<Guest> TGetList()
        {
           return _guestDal.GetList();
        }

        public void TInsert(Guest t)
        {
            _guestDal.Insert(t);
        }

        public void TUptade(Guest t)
        {
            _guestDal.Uptade(t);
        }
    }
}
