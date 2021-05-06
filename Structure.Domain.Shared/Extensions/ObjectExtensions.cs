﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Shared.Extensions
{
   public static  class ObjectExtensions
    {

        public static T As<T>(this object obj) where T : class
        {
            return (T)obj;
        }
    }
}
