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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public int TGetAppUserCount()
        {
            return _appUserDal.GetAppUserCount();  
        }

        public AppUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
           return _appUserDal.GetList();
        }

        public void TInsert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TUptade(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TUserListWithWorkLocation()
        {
            return _appUserDal.UserListWithWorkLocation();
        }

        public List<AppUser> TUserListWithWorkLocations()
        {
            return _appUserDal.UserListWithWorkLocations();
        }
    }
}
