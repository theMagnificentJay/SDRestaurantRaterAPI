using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDRestaurantRaterAPI.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public bool IsRecommended
        {
            get
            {
                return Rating > 3.5;
            }
        }
    }
}