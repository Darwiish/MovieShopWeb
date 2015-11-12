using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MovieWebDAL.Model;
using MovieWebDAL.Repository;

namespace MovieWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private Facade facade = new Facade();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
            //IEnumerable<Movie> movies = facade.GetMovieRepository().ReadAll();
            //return View(movies);
        }

    }
}
