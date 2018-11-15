using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.DbModels
{
    public class Component : BaseEntity
    {
        public string ComponentName { get; set; }
        public int Quantity { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
