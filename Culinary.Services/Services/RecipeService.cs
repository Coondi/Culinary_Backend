using AutoMapper;
using Culinary.Data.BindingModels.Recipe;
using Culinary.Data.DbModels;
using Culinary.Data.ModelsDTO;
using Culinary.Repository.Interfaces;
using Culinary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Culinary.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRepository<Recipe> recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<BaseModelDTO>> AddRecipe(AddRecipeBindingModel recipeBindingModel, IFormFile photo)
        {
            var response = new ResponseDTO<BaseModelDTO>();
            var fileName = "";

            if(photo != null)
            {
                string photosFolder = "wwwroot\\RecipePhotos";
                if(!Directory.Exists(photosFolder))
                {
                    Directory.CreateDirectory(photosFolder);
                }

                fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var path = Path.Combine(photosFolder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
            }            
           
            var recipe = _mapper.Map<Recipe>(recipeBindingModel);
            var result = await _recipeRepository.AddAsyncBool(recipe);

            if(!result)
            {
                response.Errors.Add("Wystąpił problem podczas dodawania przepisu.");
                return response;
            }
        
            return response;

        }

        public async Task<ResponseDTO<BaseModelDTO>> DeleteRecipe(int recipeId) 
        {
            var response = new ResponseDTO<BaseModelDTO>();

            var recipeExist = await _recipeRepository.ExistAsync(x => x.Id == recipeId);

            if(!recipeExist)
            {
                response.Errors.Add("Nie znaleziono takiego przepisu.");
                return response;
            }

            var recipe = await _recipeRepository.GetByAsync(x => x.Id == recipeId);
            var result = await _recipeRepository.RemoveBool(recipe);

            if(!result)
            {
                response.Errors.Add("Wystąpił problem podczas usuwania przepisu.");
                return response;
            }
      
            return response;
         
        }

        public async Task<ResponsesDTO<RecipeDTO>> GetAllRecipes()
        {
            var response = new ResponsesDTO<RecipeDTO>();

            var recipes = await _recipeRepository.GetAllAsync();
            var result = _mapper.Map<List<RecipeDTO>>(recipes);

            response.Object = result;

            return response;
        }

        public async Task<ResponseDTO<RecipeDTO>> GetRecipe(int recipeId)
        {
            var response = new ResponseDTO<RecipeDTO>();
            var recipeExist = await _recipeRepository.ExistAsync(x => x.Id == recipeId);

            if(!recipeExist)
            {
                response.Errors.Add("Nie znaleziono takiego przepisu.");
            }

            var recipe = await _recipeRepository.GetByAsync(x => x.Id == recipeId);
            var result = _mapper.Map<Recipe, RecipeDTO>(recipe);

            response.Object = result;

            return response;
            
        }

        public async Task<ResponseDTO<BaseModelDTO>> UpdateRecipe(int recipeId, UpdateRecipeBindingModel recipeBindingModel)
        {
            var response = new ResponseDTO<BaseModelDTO>();
            var recipeExist = await _recipeRepository.ExistAsync(x => x.Id == recipeId);

            if(!recipeExist)
            {
                response.Errors.Add("Nie znaleziono takiego przepisu.");
            }

            var recipe = await _recipeRepository.GetAsync(recipeId);
            var mappedRecipe = _mapper.Map(recipeBindingModel, recipe);

            if(await _recipeRepository.UpdateAsync(mappedRecipe, recipeId) == null)
            {
                return response;
            }

            return response;

        }
    }
}
