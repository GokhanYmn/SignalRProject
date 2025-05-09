using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Booking TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
