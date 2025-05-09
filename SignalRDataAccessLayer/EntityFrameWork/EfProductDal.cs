using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericREPO<Product>, IProductDal
    {
        private readonly SignalRContext _signalRContext;

        public EfProductDal(SignalRContext context) : base(context)
        {
            _signalRContext = context;
        }

        public List<Product> GetProductsWithCategories()
        {
            var values = _signalRContext.Products.Include(x=>x.Category).ToList();
           
            return values;
        }
    }
}
