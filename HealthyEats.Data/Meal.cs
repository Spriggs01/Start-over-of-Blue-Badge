
using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.WebMVC.Data
{
   

    public class Meal
    {
      
        [Required]
        public Guid UserID { get; set; }

        [Key]
        public int MealID { get; set; }

        public string MealName { get; set; }

        public string MealDescription { get; set; }

       

        public virtual ICollection<Recipe> Recipes { get; set; }


    }
}
