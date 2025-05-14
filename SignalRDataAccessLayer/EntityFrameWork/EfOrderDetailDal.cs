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
    public class EfOrderDetailDal:GenericREPO<OrderDetail>,IOrderDetailDal
    {
        private readonly SignalRContext _signalRContext;
        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
            _signalRContext = context;
        }
    }
}
