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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _sStaffDal;

        public StaffManager(IStaffDal sStaffDal)
        {
            _sStaffDal = sStaffDal;
        }

        public void TAdd(Staff t)
        {
            _sStaffDal.Add(t);
        }

        public void TDelete(Staff t)
        {
            _sStaffDal.Delete(t);
        }

        public Staff TGetBy(int id)
        {
            return _sStaffDal.GetBy(id);
        }

        public List<Staff> TGetList()
        {
           return _sStaffDal.GetList();
        }

        public void TUpdate(Staff t)
        {
            _sStaffDal.Update(t);
        }
    }
}
