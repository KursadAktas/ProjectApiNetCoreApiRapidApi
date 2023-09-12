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
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public void TAdd(Service t)
        {
            _servicesDal.Add(t);
        }

        public void TDelete(Service t)
        {
           _servicesDal.Delete(t);
        }

        public Service TGetBy(int id)
        {
            return _servicesDal.GetBy(id);
        }

        public List<Service> TGetList()
        {
           return _servicesDal.GetList();
        }

        public void TUpdate(Service t)
        {
          _servicesDal.Update(t);
        }
    }
}
