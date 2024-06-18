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
    public class CategoryService : ICategoryService
    {
        //DAL katmanındaki sınıfın referansı oluşturuldu.
        private readonly ICategoryRepository _categoryRepository;
        //BLL katmanındaki Mapping sınıfının referansı oluşturuldu. BLL ve DAL katmanlarındaki modellerin dönüşümü için eklendi.
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _categoryRepository = repository;
            _mapper = mapper;
        }

        // GetCategoryList Method
        /// <summary>
        ///  _categoryRepository.GetCategories methoduna giden ve dönüş değerini CategoryDTO'ya çeviren methottur.
        /// </summary>
        /// <returns> List<CategoryDTO> listesini döndürür.</returns>
        public List<CategoryDTO> GetCategoryList()
        {
            return _categoryRepository.GetCategories().Select(x => _mapper.Map<CategoryDTO>(x)).ToList();
        }
    }
}
