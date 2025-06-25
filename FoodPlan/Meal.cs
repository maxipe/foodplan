using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlan
{
    public class Meal
    {
        public bool Active { get; set; }
        public string Name { get; set; } = "";

        public Meal()
        {
            Active = false;
        }

        public bool IsActive()
        {
            return Active;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
