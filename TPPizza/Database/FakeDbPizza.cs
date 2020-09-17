using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPPizza.Database
{
    public class FakeDbPizza
    {

        private static readonly Lazy<FakeDbPizza> lazy =
            new Lazy<FakeDbPizza>(() => new FakeDbPizza());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDbPizza Instance { get { return lazy.Value; } }

        private FakeDbPizza()
        {
            this.ListePizza = new List<Pizza>();
            this.ListeIngredient = new List<Ingredient>();
            this.ListePate = new List<Pate>();
            this.InitialiserDatas();
        }

        public List<Pizza> ListePizza { get; private set; }

        public List<Ingredient> ListeIngredient { get; private set; }

        public List<Pate> ListePate { get; private set; }

        private void InitialiserDatas()
        {
            var i = 1;

            ListePizza.Add(new Pizza { Id = i++, Nom = "Felix", Ingredients = { "Champignon", "Jambon" }, Pate = "Pate fine, base crême" });
            ListePizza.Add(new Pizza { Id = i++, Nom = "Felix", Ingredients = {"Tomate", "Poulet" }, Pate = "Pate épaisse, base tomate" });
            ListePizza.Add(new Pizza { Id = i++, Nom = "Felix", Ingredients = { "Jambon", "Cheddar" }, Pate = "Pate épaisse, base crême" });
          
        }

    }       
}