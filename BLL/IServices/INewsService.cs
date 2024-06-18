using BLL.ServicesModel;
using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface INewsService
    {
        PaginatedNewsDTO GetPagedNewsItems(int page, int pageSize, List<ItemListDTO> list);
        List<ItemListDTO> GetNewsByCategoryId(string? categoryId);
        List<ItemListDTO> GetNewsByTitle(string? title);
        List<ItemListDTO> GetNewsByCategoryIdAndTitle(string? categoryId, string? title);
        List<ItemListDTO> GetNewsItems();
    }
}
