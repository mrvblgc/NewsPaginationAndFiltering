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
    public class NewsRepository : INewsRepository
    {
        private readonly string _jsonPath;

        public NewsRepository()
        {
            _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "DAL", "JsonData", "anasayfa.json");
        }

        // GetAllNews Method
        /// <summary>
        /// _jsonPath üzerinden okunan tüm json içeriğini NewsDataJsonModel'e aktarır.
        /// </summary>
        /// <returns>NewsDataJsonModel modelini döndürür.</returns>
        public NewsDataJsonModel? GetAllNews()
        {
            try
            {
                string jsonString = File.ReadAllText(_jsonPath);
                var newsList = JsonSerializer.Deserialize<NewsDataJsonModel>(jsonString);
                return newsList ?? new NewsDataJsonModel();
            }
            catch (IOException ex)
            {
                throw new IOException("Dosya okuma hatası", ex);
            }
            catch (JsonException ex)
            {
                throw new JsonException("JSON dönüşüm hatası", ex);
            }
        }

        // GetAllNewsByCategoryId Method
        /// <summary>
        /// _jsonPath üzerinden okunan datanın categoryId parametresine göre dataları filtreleyip getiren metottur.
        /// </summary>
        /// <returns>List<ItemListJsonModel> listesini döndürür.</returns>
        public List<ItemListJsonModel> GetAllNewsByCategoryId(string? categoryId) 
        {
            List<ItemListJsonModel> getCategoryList = new List<ItemListJsonModel>();
            if (string.IsNullOrEmpty(categoryId))
            {
                return getCategoryList;
            }

            var allItems = GetAllNewsItems();
            if (allItems.Count > 0)
            {
                getCategoryList = allItems.Where(x => x.category?.categoryId == categoryId).ToList();
            }
            return getCategoryList;
        }

        // GetAllNewsByCategoryIdAndTitle Method
        /// <summary>
        /// _jsonPath üzerinden okunan datanın categoryId ve title parametrelerine göre dataları filtreleyip getiren metottur.
        /// </summary>
        /// <returns>List<ItemListJsonModel> listesini döndürür.</returns>
        public List<ItemListJsonModel> GetAllNewsByCategoryIdAndTitle(string? categoryId, string? title)
        {
            List<ItemListJsonModel> categoryAndTitleList = new List<ItemListJsonModel>();
            if (string.IsNullOrEmpty(categoryId) || string.IsNullOrEmpty(title))
            {
                return categoryAndTitleList;
            }
            var getCategoryList = GetAllNewsByCategoryId(categoryId);
            if (getCategoryList.Count > 0)
            {
                categoryAndTitleList = getCategoryList.Where(x => x.title.ToLower().Contains(title.ToLower())).ToList();
            }
            return categoryAndTitleList;
        }

        // GetAllNewsByTitle Method
        /// <summary>
        /// _jsonPath üzerinden okunan datanın title parametresine göre dataları filtreleyip getiren metottur.
        /// </summary>
        /// <returns>List<ItemListJsonModel> listesini döndürür.</returns>
        public List<ItemListJsonModel> GetAllNewsByTitle(string? title)
        {
            List<ItemListJsonModel> titleList = new List<ItemListJsonModel>();
            List<ItemListJsonModel> allItems = GetAllNewsItems();
            if (allItems.Count > 0)
            {
                titleList = allItems.Where(x => x.title.ToLower().Contains(title.ToLower())).ToList();
            }

            return titleList;
        }

        // GetAllNewsItems Method
        /// <summary>
        /// _jsonPath üzerinden okunan datanın tümünü getiren metottur.
        /// </summary>
        /// <returns>List<ItemListJsonModel> listesini döndürür.</returns>
        public List<ItemListJsonModel> GetAllNewsItems()
        {
            List<ItemListJsonModel> allItems = new List<ItemListJsonModel>();
            var allNews = GetAllNews();
            if (allNews.data.Count > 0)
            {
                allItems = allNews?.data?.SelectMany(p => p.itemList).ToList();
            }
            return allItems;
        }
    }
}