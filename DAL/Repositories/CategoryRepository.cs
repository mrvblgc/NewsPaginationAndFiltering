using DAL.IRepositories;
using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _jsonPath;
        public CategoryRepository()
        {
            //Anasayfa.json dosyasının yolunu belirtir.
            _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "DAL", "JsonData", "anasayfa.json");
        }

        // GetCategories Method
        /// <summary>
        /// Kategorileri gruplayıp sadece 1 kez gösterecek şekilde listeleyen metottur.
        /// </summary>
        /// <returns>CategoryJsonModel döndürür.</returns>
        public List<CategoryJsonModel> GetCategories()
        {
            string jsonString = File.ReadAllText(_jsonPath);
            var newsList = JsonSerializer.Deserialize<NewsDataJsonModel>(jsonString);
            var itemList = newsList?.data?.SelectMany(p => p.itemList).ToList();

            List<CategoryJsonModel> distinctCategoryList = new List<CategoryJsonModel>();
            if (itemList.Count > 0)
            {
                distinctCategoryList = itemList.Select(x => new CategoryJsonModel
                {
                    categoryId = x.category.categoryId,
                    title = x.category.title
                }).GroupBy(x => new { x.categoryId, x.title }).Select(s => s.First()).OrderBy(x => x.title).ToList();
            }
            return distinctCategoryList;
        }
    }
}
