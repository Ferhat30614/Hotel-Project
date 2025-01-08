using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T t);//asxk askx
        void TUptade(T t);
        void TDelete(T t);
        List<T> TGetList();

        T TGetById(int id);

    }
}
