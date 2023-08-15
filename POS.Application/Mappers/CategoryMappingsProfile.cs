﻿using AutoMapper;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;

namespace POS.Application.Mappers
{
    public class CategoryMappingsProfile: Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active)? "Active" : "Inactive"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>()
                .ReverseMap();

            CreateMap<Category, CategoryResponseDto>()
                .ReverseMap();
        }
    }
}
