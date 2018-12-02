using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.DbModels
{
    public class Recipe : BaseEntity
    {
        public string RecipeName { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
        public string PhotoName { get; set; }
        public ICollection<Component> Components { get; set; }
        public ICollection<RecipeRating> RecipeRatings { get; set; }
    }
}
