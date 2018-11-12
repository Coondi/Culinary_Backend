using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.ModelsDTO
{
    public class RecipeDTO : BaseModel
    {
        public string RecipeName { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
    }
}
