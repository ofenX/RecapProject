using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class ViewCar
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
