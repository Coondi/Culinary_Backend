using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.DbModels
{
    public class RecipeRating : BaseEntity
    {
        // ????
        public int Stars { get; set; }
        public int Average { get; set; }

        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }

    }
}
