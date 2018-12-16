using Culinary.Data.BindingModels.Component;
using Culinary.Data.DbModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Culinary.Data.BindingModels.Recipe
{
    public class AddRecipeBindingModel
    {
        public string RecipeName { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        public ICollection<ComponentBindingModel> Components { get; set; }
    }
}
