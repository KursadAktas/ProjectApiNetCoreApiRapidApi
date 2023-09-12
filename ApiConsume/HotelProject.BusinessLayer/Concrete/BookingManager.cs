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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking t)
        {
           _bookingDal.Add(t);
        }

        public void TBookingStatusChangeAproved(Booking booking)
        {
            _bookingDal.BookingStatusChangeAproved(booking);
        }

        public void TBookingStatusChangeAproved2(int id)
        {
            _bookingDal.BookingStatusChangeAproved2(id);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public Booking TGetBy(int id)
        {
            return _bookingDal.GetBy(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }
    }
}
