using AutoMapper;
using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
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

        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDto>>();
            var categories = await _unitOfWork.Category.ListCategories(filters);

            if (categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<CategoryResponseDto>>(categories);
                response.Message = Replymessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDto>>();
            var categories = await _unitOfWork.Category.GetAllAsync();

            if (categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDto>>(categories);
                response.Message = Replymessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<CategoryResponseDto>> GetCategoryById(int id)
        {
            var response = new BaseResponse<CategoryResponseDto>();
            var category = await _unitOfWork.Category.GetByIdAsync(id);

            if (category is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<CategoryResponseDto>(category);
                response.Message = Replymessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var category = _mapper.Map<Category>(requestDto);
            response.Data = await _unitOfWork.Category.RegisterAsync(category);

            if(response.Data) 
            { 
                response.IsSuccess = true;
                response.Message = Replymessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_FAILED;
            }

            return response;

        }

        public async Task<BaseResponse<bool>> UpdateCategory(int id, CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await GetCategoryById(id);

            if (categoryEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_QUERY_EMPTY;
            }

            var category = _mapper.Map<Category>(requestDto);
            category.Id = id;
            response.Data = await _unitOfWork.Category.EditAsync(category);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = Replymessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteCategory(int id)
        {
            var response = new BaseResponse<bool>();
            var categoryDelete = await GetCategoryById(id);

            if (categoryDelete.Data is null)
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Category.DeleteAsync(id);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = Replymessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Replymessage.MESSAGE_FAILED;
            }

            return response;
        }

    }
}
