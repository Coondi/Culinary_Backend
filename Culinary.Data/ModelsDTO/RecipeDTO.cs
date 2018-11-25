using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.ModelsDTO
{
    public class RecipeDTO : BaseModelDTO
    {
        public string RecipeName { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
    }
}
