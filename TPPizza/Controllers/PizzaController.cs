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
            vm.Pate = FakeDbPizza.Instance.ListePate;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                vm.Pizza.Pate = FakeDbPizza.Instance.ListePate.FirstOrDefault(x => x.Id == vm.IdPate);
                FakeDbPizza.Instance.ListePate.Add(vm.Pizza.Pate);

                return RedirectToAction("Index");
            }
            catch
            {
                vm.Pate = FakeDbPizza.Instance.ListePate;
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
             Pizza pizza = FakeDbPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);

             if (pizza != null)
             {
                return View(pizza);
             }

            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Pizza pizza = null;

            try
            {
                pizza = FakeDbPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
                FakeDbPizza.Instance.ListePizza.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(pizza);
            }
        }
    }
}
