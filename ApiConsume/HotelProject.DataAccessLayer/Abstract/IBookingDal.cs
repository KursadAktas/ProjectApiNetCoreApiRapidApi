using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusChangeAproved(Booking booking);
        void BookingStatusChangeAproved2(int id );
    }
}
