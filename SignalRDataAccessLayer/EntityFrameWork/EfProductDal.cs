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
            return _signalRContext.Products.Include(x => x.Category).ToList();
        }

        public decimal HamburgerPriceAvg()
        {
            return _signalRContext.Products.Where(x => x.CategoryId == (_signalRContext.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryId).FirstOrDefault())).Average(q=>q.Price);
        }

        public int ProductCount()
        {
          return _signalRContext.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return _signalRContext.Products.Where(x=>x.CategoryId==(_signalRContext.Categories.Where(y=>y.CategoryName=="İçecek").Select(z=>z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return _signalRContext.Products.Where(x => x.CategoryId == (_signalRContext.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public decimal ProductPriceAvg()
        {
           return _signalRContext.Products.Average(x => x.Price);
        }

        public string ProductPriceMax()
        {
            return _signalRContext.Products.Where(x => x.Price==(_signalRContext.Products.Max(y=>y.Price))).Select(z=>z.ProductName).FirstOrDefault();
        }

        public string ProductPriceMin()
        {
            return _signalRContext.Products.Where(x => x.Price == (_signalRContext.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }
    }
}
