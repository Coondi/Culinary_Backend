using Culinary.Data.BindingModels.Recipe;
using Culinary.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Culinary.WebApi.Controllers
{
    [Route("Recipe")]
    [Authorize]
    public class RecipeController : BaseResponseController
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddRecipe([FromForm] AddRecipeBindingModel model)
        {                 
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            var userId = User.Identity.Name;
            var result = await _recipeService.AddRecipe(model, model.photo);

            if(result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        
        }

        [HttpPut("Update/{recipeId}")]
        public async Task<IActionResult> UpdateRecipe(int recipeId, [FromForm] UpdateRecipeBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            var result = await _recipeService.UpdateRecipe(recipeId, model, model.Photo);

            if (result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("Delete/{recipeId}")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {

            var result = await _recipeService.DeleteRecipe(recipeId);

            if(result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("AllRecipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();

            if(recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpGet("OneRecipe/{recipeId}")]
        public async Task<IActionResult> GetRecipe(int recipeId)
        {
            var recipe = await _recipeService.GetRecipe(recipeId);

            if(recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

    }
}
