using AutoMapper;
using BLL.IServices;
using BLL.ServicesModel;
using DAL.IRepositories;
using DAL.JsonModel;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsDetailService : INewsDetailService
    {
        //DAL katmanındaki sınıfın referansı oluşturuldu.
        private readonly INewsDetailRepository _newsDetailRepository;
        //BLL katmanındaki Mapping sınıfının referansı oluşturuldu. BLL ve DAL katmanlarındaki modellerin dönüşümü için eklendi.
        private readonly IMapper _mapper;
        public NewsDetailService(INewsDetailRepository repository, IMapper mapper)
        {
            _newsDetailRepository = repository;
            _mapper = mapper;
        }

        // GetNewsDetailById Method
        /// <summary>
        /// itemId parametresini _newsDetailRepository.GetNewsDetailById methoduna gönderen ve dönüş değerini NewsDetailDTO'ya çeviren methottur.
        /// </summary>
        /// <returns> NewsDetailDTO listesini döndürür.</returns>
        public NewsDetailDTO GetNewsDetailById(string? itemId)
        {
            return _mapper.Map<NewsDetailDTO>(_newsDetailRepository.GetNewsDetailById(itemId));
        }
    }
}
