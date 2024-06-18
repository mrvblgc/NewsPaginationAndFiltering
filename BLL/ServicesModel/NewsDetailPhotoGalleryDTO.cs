using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesModel
{
    public class NewsDetailPhotoGalleryDTO
    {
        public string? shortText { get; set; }
        public string? bodyText { get; set; }
        public string? videoUrl { get; set; }
        public string? itemId { get; set; }
        public string? title { get; set; }
        public string? imageUrl { get; set; }
        public string? itemType { get; set; }
        public bool titleVisible { get; set; }
    }
}
