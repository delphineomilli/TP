using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPPizza.Database;
using TPPizza.Models;

namespace TPPizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDbPizza.Instance.ListePizza);
        }


        // GET: Pizza/Create
        public ActionResult Create()
        {

            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pates = FakeDbPizza.Instance.PatesDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList(); // To list c'est pour éviter un pb de cast

            vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                if (ModelState.IsValid && ValidateVM(vm))
                {
                    // Pizza pizza = vm.Pizza;

                    vm.Pizza.Pate = FakeDbPizza.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);

                    vm.Pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Where(x => vm.IdIngredients.Contains(x.Id)).ToList();
                    //si jamais la liste est vide on prend lid 1 sinon on prend l'id le plus grand et on ajoute 1
                    vm.Pizza.Id = FakeDbPizza.Instance.ListePizza.Count == 0 ? 1 : FakeDbPizza.Instance.ListePizza.Max(x => x.Id) + 1;

                    FakeDbPizza.Instance.ListePizza.Add(vm.Pizza);


                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Pates = FakeDbPizza.Instance.PatesDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    
                    vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    
                    return View(vm);
                }
            }
            catch
            {
                vm.Pates = FakeDbPizza.Instance.PatesDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

                vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

                return View(vm);
            }
        }

        private bool ValidateVM(PizzaCreateViewModel vm)
        {
            bool result = true;
            return result;
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();

            vm.Pates = FakeDbPizza.Instance.PatesDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Pizza = FakeDbPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);

           if (vm.Pizza.Pate != null)
           {
                vm.IdPate = vm.Pizza.Pate.Id;
           }

           if (vm.Pizza.Ingredients.Any())
           {
                vm.IdIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
           }
           
            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDbPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDbPizza.Instance.PatesDisponible.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponible.Where(x => vm.IdIngredients.Contains(x.Id)).ToList();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
             vm.Pizza = FakeDbPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
    
             return View(vm);

        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
           
            try
            {
               
                Pizza pizza = FakeDbPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
                FakeDbPizza.Instance.ListePizza.Remove(pizza);
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }
    }
}
