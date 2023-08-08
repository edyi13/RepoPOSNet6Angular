using AutoMapper;
using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validationRules;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validationRules)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
        }

        public Task<BaseResponse<CategoryResponseDto>> GetCategoriesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> UpdateCategory(int id, CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

    }
}
