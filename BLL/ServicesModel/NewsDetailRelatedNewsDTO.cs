using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesModel
{
    public class NewsDetailRelatedNewsDTO
    {
        public bool hasPhotoGallery { get; set; }
        public bool hasVideo { get; set; }
        public string? publishDate { get; set; }
        public string? shortText { get; set; }
        public DetailCategoryDTO? category { get; set; }
        public string? itemId { get; set; }
        public string? title { get; set; }
        public string? imageUrl { get; set; }
        public string? itemType { get; set; }
        public bool titleVisible { get; set; }
    }
}
