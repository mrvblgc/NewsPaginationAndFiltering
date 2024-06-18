using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface INewsRepository
    {
        NewsDataJsonModel GetAllNews();

        List<ItemListJsonModel> GetAllNewsByCategoryId(string? categoryId);
        List<ItemListJsonModel> GetAllNewsByTitle(string? title);

        List<ItemListJsonModel> GetAllNewsByCategoryIdAndTitle(string? categoryId, string? title);

        List<ItemListJsonModel> GetAllNewsItems();
    }
}
