﻿using Core.Entities;
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
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<CarImage> CarImages { get; set; }
        public virtual Color Color { get; set; }
        public int FindeksScore { get; set; }
    }
}
