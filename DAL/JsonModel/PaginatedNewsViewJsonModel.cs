using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonModel
{
    public class PaginatedNewsViewJsonModel
    {
        public List<ItemListJsonModel>? News { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
