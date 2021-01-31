﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity 
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public override string ToString()
        { 
                return $"Id: " + Id + " BrandId: " + BrandId + " ColorId: " + ColorId + 
                    " ModelYear: " + ModelYear + " DailyPrice: " + DailyPrice + 
                    " Description: " + Description;
             
        }
    }
}
