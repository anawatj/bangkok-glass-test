using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICommonService
    {
        List<SelectItemDto> GetRegions();

        List<SelectItemDto> GetCities(string regionId);

        List<SelectItemDto> GetCategories();

        List<SelectItemDto> GetProducts(string categoryId);
    }
}
