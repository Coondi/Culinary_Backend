using AutoMapper;
using Culinary.Data.BindingModels.Recipe;
using Culinary.Data.DbModels;
using Culinary.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culinary.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMappings();
        }

        public void CreateMappings()
        {
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            CreateMap<Recipe, AddRecipeBindingModel>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeBindingModel>().ReverseMap();
        }

    }
}
