using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesModel
{
    public class PaginatedNewsDTO
    {
        public List<ItemListDTO>? News { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public List<CategoryDTO> categoryList {get;set;} 
    }
}
