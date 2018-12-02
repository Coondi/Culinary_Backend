using Culinary.Data.BindingModels.Recipe;
using Culinary.Data.ModelsDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Culinary.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<ResponseDTO<BaseModelDTO>> AddRecipe(AddRecipeBindingModel recipeBindingModel, IFormFile photo);
        Task<ResponseDTO<BaseModelDTO>> UpdateRecipe(int recipeId, UpdateRecipeBindingModel recipeBindingModel);
        Task<ResponseDTO<BaseModelDTO>> DeleteRecipe(int recipeId);
        Task<ResponsesDTO<RecipeDTO>> GetAllRecipes();
        Task<ResponseDTO<RecipeDTO>> GetRecipe(int recipeId);
        
    }
}
