﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonModel
{
    public class DataListJsonModel
    {
        public string? sectionType { get; set; }
        public string? repeatType { get; set; }
        public int itemCountInRow { get; set; }
        public bool lazyLoadingEnabled { get; set; }
        public bool titleVisible { get; set; }
        public string? title { get; set; }
        public string? titleColor { get; set; }
        public string? titleBgColor { get; set; }
        public string? sectionBgColor { get; set; }
        public List<ItemListJsonModel>? itemList { get; set; }
        public int totalRecords { get; set; }
    }
}
