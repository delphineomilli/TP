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
            this.IngredientsDisponible = this.InitIngredientsDisponibles();
            this.PatesDisponible = this.InitPatesDisponibles();
        }

        public List<Pizza> ListePizza { get; private set; }

        public List<Ingredient> IngredientsDisponible { get; private set; }

        public List<Pate> PatesDisponible { get; private set; }

        private List<Ingredient> InitIngredientsDisponibles()
        {
            List<Ingredient> result = new List<Ingredient>();
            result.Add(new Ingredient { Id = 1, Nom = "Mozzarella" });
            result.Add(new Ingredient { Id = 2, Nom = "Jambon" });
            result.Add(new Ingredient { Id = 3, Nom = "Tomate" });
            result.Add(new Ingredient { Id = 4, Nom = "Oignon" });
            result.Add(new Ingredient { Id = 5, Nom = "Cheddar" });
            result.Add(new Ingredient { Id = 6, Nom = "Saumon" });
            result.Add(new Ingredient { Id = 7, Nom = "Champignon" });
            result.Add(new Ingredient { Id = 8, Nom = "Poulet" });

            return result;
        }

        private List<Pate> InitPatesDisponibles()
        {
            List<Pate> result = new List<Pate>();
            result.Add(new Pate { Id = 1, Nom = "Pate fine, base crême" });
            result.Add(new Pate { Id = 2, Nom = "Pate fine, base tomate" });
            result.Add(new Pate { Id = 3, Nom = "Pate épaisse, base crême" });
            result.Add(new Pate { Id = 4, Nom = "Pate épaisse, base tomate" });

            return result;
        }





    }       
}