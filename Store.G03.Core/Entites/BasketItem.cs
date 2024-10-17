using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core.Entites
{
    public class BasketItem 
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string PictureUrl { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }

    }
}
