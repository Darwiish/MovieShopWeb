using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreGateWay;
using MovieStoreMVCDto;

namespace MovieStoreManagement.Controllers
{
    public class MovieController : Controller
    {
        Facade fac = new Facade();
        // GET: Movie
        public ActionResult Index()
        {
            return View(fac.GetMovieGateway().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(fac.GetMovieGateway().ReadAll(), "Genre.Id", "Genre.Name");
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie mov,FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetMovieGateway().Add(mov);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(fac.GetMovieGateway().ReadAll());
            return View();
        }

        // GET: Movie/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = fac.GetMovieGateway().Get(id);
            ViewBag.GenreId = new SelectList(fac.GetMovieGateway().ReadAll(), "Genre.Id", "Genre.Name", movie);
            return View(movie);
        }

        // POST: Movie/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                fac.GetMovieGateway().Edit(movie);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(fac.GetMovieGateway().ReadAll(), "GenreId", "Name", movie);
            return View();
            
        }

        // GET: Movie/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = fac.GetMovieGateway().Get(id);
            return View(movie);
        }
        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                fac.GetMovieGateway().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
