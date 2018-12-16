using Culinary.Data.BindingModels.Component;
using Culinary.Data.DbModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.BindingModels.Recipe
{
    public class UpdateRecipeBindingModel
    {
        public string RecipeName { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        public ICollection<ComponentBindingModel> Components { get; set; }
    }
}
