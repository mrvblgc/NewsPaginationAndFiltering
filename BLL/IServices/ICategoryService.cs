using BLL.ServicesModel;
using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetCategoryList();
    }
}
