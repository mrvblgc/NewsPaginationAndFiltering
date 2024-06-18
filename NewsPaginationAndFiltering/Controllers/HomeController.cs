using BLL.IServices;
using BLL.Services;
using BLL.ServicesModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsPaginationAndFiltering.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NewsPaginationAndFiltering.Controllers
{
    public class HomeController : Controller
    {
        //BLL katmanýndaki sýnýflarýn referanslarý oluþturuldu.
        private readonly INewsService _newsService;
        private readonly INewsDetailService _newsDetailService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;
        private const int pageSize = 5;

        //Yukarýda oluþturulan referanslar HomeController sýnýfýnýn constructor metoduna parametreler ile dahil edildi.
        public HomeController(ILogger<HomeController> logger, INewsService newsService, ICategoryService categoryService, INewsDetailService newsDetailService)
        {
            _logger = logger;
            _newsService = newsService;
            _categoryService = categoryService;
            _newsDetailService = newsDetailService;
        }

        // GET: /Home/Index
        /// <summary>
        /// Anasayfadaki Kategori listesini select içerisine doldurmak için kullanýlýr.
        /// </summary>
        /// <returns>PaginatedNewsDTO içerisindeki category listesini Index View'ýna gönderir.</returns>
        public IActionResult Index()
        {
            PaginatedNewsDTO model = new PaginatedNewsDTO();
            try
            {
                model.categoryList = _categoryService.GetCategoryList();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return View(model);
            }
        }

        // GET: /Home/GetNews
        /// <summary>
        /// Anasayfa ilk yüklendiðinde ya da buton tetiklendiðinde (kategori ya da arama kelimesine göre) sayfayý doldurmaya yarayan methottur. Sayfanýn sürekli reflesh olmasý engellenir.
        /// </summary>
        /// <returns>PaginatedNewsDTO modeli dolduralarak Json deðerine döndürülür.</returns>
        public JsonResult GetNews(int page = 1, string? category = null, string? search = null)
        {
            PaginatedNewsDTO model = new PaginatedNewsDTO();
            try
            {
                List<ItemListDTO> allItems = new List<ItemListDTO>();
                if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(search))
                {
                    //BLL katmanýndaki GetNewsByCategoryIdAndTitle methoduna category, search parametrelerini gönderir. Geriye PaginatedNewsDTO modelini döndürür.
                    allItems = _newsService.GetNewsByCategoryIdAndTitle(category, search);
                }
                else if (!string.IsNullOrEmpty(search) && string.IsNullOrEmpty(category))
                {
                    //BLL katmanýndaki GetNewsByTitle methoduna search parametrelesini gönderir. Geriye PaginatedNewsDTO modelini döndürür.
                    allItems = _newsService.GetNewsByTitle(search);
                }
                else if (!string.IsNullOrEmpty(category) && string.IsNullOrEmpty(search))
                {
                    //BLL katmanýndaki GetNewsByCategoryId methoduna category parametrelesini gönderir. Geriye PaginatedNewsDTO modelini döndürür.
                    allItems = _newsService.GetNewsByCategoryId(category);
                }
                else
                {   //Hiç bir filtreleme yapmadan tüm datalarý getirir. BLL katmanýndaki GetNewsItems methoduna gönderir. Geriye PaginatedNewsDTO modelini döndürür.
                    allItems = _newsService.GetNewsItems();
                }

                //Sayfalama iþlemi için kullanýlýr. BLL katmanýndaki GetPagedNewsItems methoduna page, pageSize, allItems parametrelerini gönderir.
                model = _newsService.GetPagedNewsItems(page, pageSize, allItems);
                model.categoryList = _categoryService.GetCategoryList();

                return Json(new { news = model.News, totalPages = model.TotalPages, pageSize });
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return Json(new { news = model.News, totalPages = model.TotalPages, pageSize });
            }
        }

        // GET: /Home/Detail
        /// <summary>
        /// Anasayfa üzerindeki ilgili haberin detay bilgilerini itemId parametresine göre getirir.
        /// </summary>
        /// <returns>NewsDetailDTO modelini döndürür.</returns>
        public IActionResult Detail(string? itemId = null)
        {
            NewsDetailDTO model = new NewsDetailDTO();
            try
            {
                model = _newsDetailService.GetNewsDetailById(itemId);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return View(model);
            }
        }
    }
}
