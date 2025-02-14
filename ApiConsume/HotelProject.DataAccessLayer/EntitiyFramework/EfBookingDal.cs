using HotelProject.DataAccessLayer.Abstarct;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntitiyFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusChangeApproved(Booking booking)
        {
           Context context=new Context();
           var values=context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved2(int id)
        {
            Context context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();

        }

        public int GetBookingCount()
        {
           Context context=new Context();   
            var values=context.Bookings.Count();
            return values;  
        }

        public List<Booking> Last6Bookings()
        {
            Context context=new Context();  
            var values=context.Bookings.OrderByDescending(x=>x.BookingID).Take(6).ToList();
            return values;
        }
    }
}
