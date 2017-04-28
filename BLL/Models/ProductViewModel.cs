using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public short? Stock { get; set; }
        public decimal? Price { get; set; }
    }
}