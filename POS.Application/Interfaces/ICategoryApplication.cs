using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories(BaseFiltersRequest filters);
        Task<BaseResponse<CategoryResponseDto>> GetCategoriesById(int id);
        Task<BaseResponse<bool>>RegisterCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>>UpdateCategory(int id, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteCategory(int id);
    }
}
