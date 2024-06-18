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
    public class NewsDetailRepository : INewsDetailRepository
    {
        //DAL katmanındaki sınıfların referansları oluşturuldu.
        private readonly INewsRepository _newReporsitory;
        private readonly string _jsonDetailPath;

        public NewsDetailRepository(INewsRepository repository)
        {
            _jsonDetailPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "DAL", "JsonData", "detay.json");
            _newReporsitory = repository;
        }

        // GetNewsDetail Method
        /// <summary>
        /// _jsonPath üzerinden okunan tüm json içerğini NewDetailMainJsonModel'e aktarır.
        /// </summary>
        /// <returns>NewDetailMainJsonModel modelini döndürür.</returns>
        public NewDetailMainJsonModel GetNewsDetail()
        {
            try
            {
                string jsonString = File.ReadAllText(_jsonDetailPath);
                var newsList = JsonSerializer.Deserialize<NewDetailMainJsonModel>(jsonString);
                return newsList ?? new NewDetailMainJsonModel();
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

        // GetNewsDetailById Method
        /// <summary>
        /// _jsonDetailPath üzerinden okunan datanın itemId parametresine göre dataları filtreleyip getiren metottur.
        /// </summary>
        /// <returns>NewsDetailJsonModel döndürür.</returns>
        public NewsDetailJsonModel GetNewsDetailById(string? itemId)
        {
            NewsDetailJsonModel model = new NewsDetailJsonModel();
            var allItems = GetNewsDetail();
            NewsDetailJsonModel? newsDetail = allItems.data?.newsDetail;
            if (newsDetail?.itemId == itemId)
            {
                model.itemId = newsDetail.itemId;
                model.publishDate = newsDetail.publishDate;
                model.bodyText = newsDetail.bodyText;
                model.shortText = newsDetail.shortText;
                model.resource = newsDetail.resource;
                model.fullPath = newsDetail.fullPath;   
                model.hasPhotoGallery = newsDetail.hasPhotoGallery;
                model.hasVideo = newsDetail.hasVideo;
                model.title = newsDetail.title;
                model.imageUrl = newsDetail.imageUrl;
                model.itemType = newsDetail.itemType;
                model.category = newsDetail.category;
                model.category.categoryId = newsDetail.category.categoryId;
                model.category.title = newsDetail.category.title;
                model.category.slug = newsDetail.category.slug;
                model.category.color = newsDetail.category.color;
            }
            return model;
        }
    }
}
