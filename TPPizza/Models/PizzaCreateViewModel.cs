using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPPizza.Models
{
    public class PizzaCreateViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pate { get; set; } 
        public int IdPate { get; set; }




        //A revoir car il faut renvoyer plusieurs id d'ingredients à l'utilisateur
        public List<Ingredient> Ingredient { get; set; }
        public int IdIngredient { get; set; }




    }
}