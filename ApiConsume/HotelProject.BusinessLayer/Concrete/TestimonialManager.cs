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
    public class TestimonialManager : ITestimonialService
    {

        private readonly ITestimonialDal _testimonialDal;
        public void TDelete(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TUptade(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
