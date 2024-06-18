using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonModel
{
    public class NewsDataJsonModel
    {
        public int errorCode { get; set; }
        public string? errorMessage { get; set; }
        public List<DataListJsonModel>? data { get; set; }
    }
}
