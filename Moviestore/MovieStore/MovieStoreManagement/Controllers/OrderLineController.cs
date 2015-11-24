using MovieStoreGateWay;
using MovieStoreMVCDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreManagement.Controllers
{
    public class OrderLineController : Controller
    {
        Facade fac = new Facade();
        public ActionResult Index(int id)
        {
            return View(/*fac.GetOrderLineGateway().ReadAll(id)*/);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var OL = fac.GetOrderLineGateway().Get(id);
            ViewBag.MovieId = new SelectList(fac.GetMovieGateway().ReadAll(), "Movie.Id", "Movie.Title", OL);
            return View(OL);
        }

        // POST: OrderLine/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderLine OL, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetOrderLineGateway().Edit(OL);
                return RedirectToAction("Index", new {id = OL.OrderId });
            }
            ViewBag.MovieId = new SelectList(fac.GetMovieGateway().ReadAll(), "Movie.Id", "Movie.Title", OL);

            return View();
        }

        // GET: OrderLine/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var OL = fac.GetOrderLineGateway().Get(id);
            return View(OL);
        }

        // POST: OrderLine/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int OrderID = fac.GetOrderLineGateway().Get(id).OrderId;
            if (ModelState.IsValid)
            {
                fac.GetOrderLineGateway().Delete(id);
                return RedirectToAction("Index", new {id =  OrderID});
            }
                return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(fac.GetMovieGateway().ReadAll(), "Movie.Id", "Movie.Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderLine OL, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetOrderLineGateway().Add(OL);
                return RedirectToAction("Index", new {id = OL.Id });
            }
            ViewBag.MovieId = new SelectList(fac.GetMovieGateway().ReadAll(), "Movie.Id", "Movie.Title");
            return View();
        }

    }
}
