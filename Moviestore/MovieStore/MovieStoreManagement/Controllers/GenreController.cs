using MovieStoreGateWay;
using MovieStoreMVCDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreManagement.Controllers
{
    public class GenreController : Controller
    {
        Facade fac = new Facade();
        public ActionResult Index()
        {
            return View(fac.GetGenerrGateway().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetGenerrGateway().Add(genre);
                return RedirectToAction("Index");
            }
            
                return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(fac.GetGenerrGateway().Get(id));
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(Genre genre, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetGenerrGateway().Edit(genre);
                return RedirectToAction("Index");
            }
                return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(fac.GetGenerrGateway().Get(id));
        }

        // POST: Genre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetGenerrGateway().Delete(id);
                return RedirectToAction("Index");
            }

            return View();
            
        }
    }
}
