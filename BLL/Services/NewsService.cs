using BLL.IServices;
using DAL.IRepositories;
using BLL.ServicesModel;
using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class NewsService : INewsService
    {
        //DAL katmanındaki sınıfın referansı oluşturuldu.
        private readonly INewsRepository _newsRepository;
        //BLL katmanındaki Mapping sınıfının referansı oluşturuldu. BLL ve DAL katmanlarındaki modellerin dönüşümü için eklendi.
        private readonly IMapper _mapper;
        public NewsService(INewsRepository repository, IMapper mapper)
        {
            _newsRepository = repository;
            _mapper = mapper;
        }

        // GetPagedNewsItems Method
        /// <summary>
        /// page,pageSize ve list parametrelerine göre sayfalama işlemi yapan metottur.
        /// </summary>
        /// <returns>PaginatedNewsDTO modelini döndürür.</returns>
        public PaginatedNewsDTO GetPagedNewsItems(int page, int pageSize, List<ItemListDTO> list)
        {
            try
            {
                var totalCount = list?.Count ?? 0;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                if (page < 1)
                {
                    page = 1;
                }
                else if (page > totalPages && totalPages > 0)
                {
                    page = totalPages;
                }

                var pagedData = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var paginatedModel = new PaginatedNewsDTO
                {
                    News = pagedData,
                    CurrentPage = page,
                    TotalPages = totalPages
                };
                return paginatedModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Sayfalama işlemi yapılırken hata oluştu" + ex);
            }
        }

        // GetNewsByCategoryId Method
        /// <summary>
        /// categoryId parametresini _newsRepository.GetAllNewsByCategoryId methoduna gönderen ve dönüş değerini ItemListDTO'ya çeviren methottur.
        /// </summary>
        /// <returns> List<ItemListDTO> listesini döndürür.</returns>
        public List<ItemListDTO> GetNewsByCategoryId(string? categoryId)
        {
            return _newsRepository.GetAllNewsByCategoryId(categoryId).Select(x => _mapper.Map<ItemListDTO>(x)).ToList();
        }

        // GetNewsByTitle Method
        /// <summary>
        /// title parametresini _newsRepository.GetAllNewsByTitle methoduna gönderen ve dönüş değerini ItemListDTO'ya çeviren methottur.
        /// </summary>
        /// <returns> List<ItemListDTO> listesini döndürür.</returns>
        public List<ItemListDTO> GetNewsByTitle(string? title)
        {
            return _newsRepository.GetAllNewsByTitle(title).Select(x => _mapper.Map<ItemListDTO>(x)).ToList(); ;
        }

        // GetNewsByCategoryIdAndTitle Method
        /// <summary>
        /// categoryId ve title parametrelerini _newsRepository.GetAllNewsByCategoryIdAndTitle methoduna gönderen ve dönüş değerini ItemListDTO'ya çeviren methottur.
        /// </summary>
        /// <returns> List<ItemListDTO> listesini döndürür.</returns>
        public List<ItemListDTO> GetNewsByCategoryIdAndTitle(string? categoryId, string? title)
        {
            return _newsRepository.GetAllNewsByCategoryIdAndTitle(categoryId, title).Select(x => _mapper.Map<ItemListDTO>(x)).ToList();
        }

        // GetNewsItems Method
        /// <summary>
        ///  _newsRepository.GetAllNewsItems methoduna giden ve dönüş değerini ItemListDTO'ya çeviren methottur.
        /// </summary>
        /// <returns> List<ItemListDTO> listesini döndürür.</returns>
        public List<ItemListDTO> GetNewsItems()
        {
            return _newsRepository.GetAllNewsItems().Select(x => _mapper.Map<ItemListDTO>(x)).ToList(); ;
        }
    }
}
