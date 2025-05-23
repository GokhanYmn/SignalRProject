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
    public class EfContactDal : GenericREPO<Contact>, IContactDal
    {
        private readonly SignalRContext _signalRContext;
        public EfContactDal(SignalRContext context) : base(context)
        {
            _signalRContext = context;
        }
    }
}
