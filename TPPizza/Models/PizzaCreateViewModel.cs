using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPPizza.Models
{
    public class PizzaCreateViewModel
    {
        public Pizza Pizza { get; set; }
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        //renvoyer plusieurs id d'ingredients à l'utilisateur
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();

        [Required]
        public int? IdPate { get; set; }   // int? permet d'être null si l'utilisateur n'a rien sélectionner
        public List<int> IdIngredients { get; set; } = new List<int>();




    }
}