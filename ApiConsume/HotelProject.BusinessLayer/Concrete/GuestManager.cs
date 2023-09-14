using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
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

        public void TAdd(Guest t)
        {
            _guestDal.Add(t);
        }

        public void TDelete(Guest t)
        {
            _guestDal.Delete(t);
        }

        public Guest TGetBy(int id)
        {
           return _guestDal.GetBy(id);
        }

        public List<Guest> TGetList()
        {
            return _guestDal.GetList();
        }

        public void TUpdate(Guest t)
        {
            _guestDal.Update(t);
        }
    }
}
