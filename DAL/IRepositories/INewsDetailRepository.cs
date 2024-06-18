using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface INewsDetailRepository
    {
        NewsDetailJsonModel GetNewsDetailById(string? itemId);

        NewDetailMainJsonModel GetNewsDetail();
    }
}
