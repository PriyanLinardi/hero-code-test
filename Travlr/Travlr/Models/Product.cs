using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travlr.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool liveAvailability { get; set; }
        public int confirmationType { get; set; }
        public int availability { get; set; }
        public int minStay { get; set; }
        public int maxStay { get; set; }
        public string validFrom { get; set; }
        public string validTo { get; set; }
        public int advertisedPrice { get; set; }
        public int commission { get; set; }
    }
}