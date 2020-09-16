using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1Module5.Database;

namespace TP1Module5.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View(FakeDb.Instance.GetMeuteDeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDb.Instance.GetMeuteDeChats.FirstOrDefault(chat => chat.Id == id));
        }


        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
