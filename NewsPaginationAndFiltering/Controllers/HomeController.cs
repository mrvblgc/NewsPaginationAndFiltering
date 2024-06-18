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
        //BLL katman�ndaki s�n�flar�n referanslar� olu�turuldu.
        private readonly INewsService _newsService;
        private readonly INewsDetailService _newsDetailService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;
        private const int pageSize = 5;

        //Yukar�da olu�turulan referanslar HomeController s�n�f�n�n constructor metoduna parametreler ile dahil edildi.
        public HomeController(ILogger<HomeController> logger, INewsService newsService, ICategoryService categoryService, INewsDetailService newsDetailService)
        {
            _logger = logger;
            _newsService = newsService;
            _categoryService = categoryService;
            _newsDetailService = newsDetailService;
        }

        // GET: /Home/Index
        /// <summary>
        /// Anasayfadaki Kategori listesini select i�erisine doldurmak i�in kullan�l�r.
        /// </summary>
        /// <returns>PaginatedNewsDTO i�erisindeki category listesini Index View'�na g�nderir.</returns>
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
        /// Anasayfa ilk y�klendi�inde ya da buton tetiklendi�inde (kategori ya da arama kelimesine g�re) sayfay� doldurmaya yarayan methottur. Sayfan�n s�rekli reflesh olmas� engellenir.
        /// </summary>
        /// <returns>PaginatedNewsDTO modeli dolduralarak Json de�erine d�nd�r�l�r.</returns>
        public JsonResult GetNews(int page = 1, string? category = null, string? search = null)
        {
            PaginatedNewsDTO model = new PaginatedNewsDTO();
            try
            {
                List<ItemListDTO> allItems = new List<ItemListDTO>();
                if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(search))
                {
                    //BLL katman�ndaki GetNewsByCategoryIdAndTitle methoduna category, search parametrelerini g�nderir. Geriye PaginatedNewsDTO modelini d�nd�r�r.
                    allItems = _newsService.GetNewsByCategoryIdAndTitle(category, search);
                }
                else if (!string.IsNullOrEmpty(search) && string.IsNullOrEmpty(category))
                {
                    //BLL katman�ndaki GetNewsByTitle methoduna search parametrelesini g�nderir. Geriye PaginatedNewsDTO modelini d�nd�r�r.
                    allItems = _newsService.GetNewsByTitle(search);
                }
                else if (!string.IsNullOrEmpty(category) && string.IsNullOrEmpty(search))
                {
                    //BLL katman�ndaki GetNewsByCategoryId methoduna category parametrelesini g�nderir. Geriye PaginatedNewsDTO modelini d�nd�r�r.
                    allItems = _newsService.GetNewsByCategoryId(category);
                }
                else
                {   //Hi� bir filtreleme yapmadan t�m datalar� getirir. BLL katman�ndaki GetNewsItems methoduna g�nderir. Geriye PaginatedNewsDTO modelini d�nd�r�r.
                    allItems = _newsService.GetNewsItems();
                }

                //Sayfalama i�lemi i�in kullan�l�r. BLL katman�ndaki GetPagedNewsItems methoduna page, pageSize, allItems parametrelerini g�nderir.
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
        /// Anasayfa �zerindeki ilgili haberin detay bilgilerini itemId parametresine g�re getirir.
        /// </summary>
        /// <returns>NewsDetailDTO modelini d�nd�r�r.</returns>
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
