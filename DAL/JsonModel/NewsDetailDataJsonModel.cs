using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonModel
{
    public class NewsDetailDataJsonModel
    {
        public NewsDetailHeaderAdJsonModel? headerAd { get; set; }
        public NewsDetailJsonModel? newsDetail { get; set; }
        public NewsDetailHeaderAdJsonModel? footerAd { get; set; }
        public NewDetailMultimediaJsonModel? multimedia { get; set; }
        public List<NewsDetailItemJsonModel>? itemList { get; set; }
        public NewsDetailRelatedNewsJsonModel? relatedNews { get; set; }
        public NewsDetailVideoJsonModel? video { get; set; }
        public NewsDetailPhotoGalleryJsonModel? photoGallery { get; set; }
    }
}
