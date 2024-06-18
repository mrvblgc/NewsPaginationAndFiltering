using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesModel
{
    public class NewsDataDTO
    {
        public int errorCode { get; set; }
        public string? errorMessage { get; set; }
        public List<DataListDTO>? data { get; set; }
    }
}
