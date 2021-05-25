﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SDRestaurantRaterAPI.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("DefaultConnection") { }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}