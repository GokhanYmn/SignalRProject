﻿using SignalRDataAccessLayer.Abstract;
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
    public class EfCategoryDal : GenericREPO<Category>, ICategoryDal
    {
        private readonly SignalRContext _signalRContext;
        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _signalRContext = context;
        }

        public int ActiveCategoryCount()
        {
           return _signalRContext.Categories.Where(x=>x.Status==true).Count();
        }

        public int CategoryCount()
        {
           
            return _signalRContext.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            return _signalRContext.Categories.Where(x => x.Status == false).Count();
        }
    }
}
