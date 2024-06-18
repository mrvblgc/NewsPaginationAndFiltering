using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.JsonModel
{
    public class NewDetailMainJsonModel
    {
        public int errorCode { get; set; }
        public string? errorMessage { get; set; }
        public NewsDetailDataJsonModel? data { get; set; }
    }
}
