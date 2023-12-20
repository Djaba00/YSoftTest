using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YSoftTest.Models;

namespace YSoftTest.ViewModels
{
    public class ProductPageViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public PageViewModel Page { get; set; }


    }
}