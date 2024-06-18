using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesModel
{
    public class NewsDetailDataDTO
    {
        public NewsDetailHeaderAdDTO? headerAd { get; set; }
        public NewsDetailDTO? newsDetail { get; set; }
        public NewsDetailHeaderAdDTO? footerAd { get; set; }
        public NewDetailMultimediaDTO? multimedia { get; set; }
        public List<NewsDetailItemDTO>? itemList { get; set; }
        public NewsDetailRelatedNewsDTO? relatedNews { get; set; }
        public NewsDetailVideoDTO? video { get; set; }
        public NewsDetailPhotoGalleryDTO? photoGallery { get; set; }
    }
}
