using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class SearchViewModel
    {
        public string ModelSearch { get; set; }

        public string ManufacturerSearch { get; set; }

        public decimal PriceSearch { get; set; }
    }
}