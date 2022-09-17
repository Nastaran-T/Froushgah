﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class ShopeItem
    {
        public int ProductID { get; set; }
        public int Count { get; set; }
    }

    public class ShopCartViewModel
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
    }

    public class ShopOrderViewModel
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
    }

}

