using HealthyEats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtyEats.Models
{
    public class FavoriteRecipeCreate
    {

        public string FavoriteList { get; set; }

       
        public virtual ICollection<Recipe> Recipes { get; set; }

        public override string ToString() => FavoriteList;
    }
}
