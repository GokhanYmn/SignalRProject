using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFrameWork
{
    public class EfOrderDal: GenericREPO<Order>, IOrderDal
    {
        private readonly SignalRContext _signalRContext;
        public EfOrderDal(SignalRContext context) : base(context)
        {
            _signalRContext = context;
        }

        public int ActiveOrderCount()
        {
            return _signalRContext.Orders.Where(x=>x.Description=="Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            return _signalRContext.Orders.LastOrDefault().TotalPrice;
        }

        public int TotalOrderCount()
        {
            return _signalRContext.Orders.Count();
        }
    }
}
