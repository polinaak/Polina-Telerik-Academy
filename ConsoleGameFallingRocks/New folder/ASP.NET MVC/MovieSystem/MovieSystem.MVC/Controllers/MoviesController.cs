using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieSystem.Models;
using MovieSystem.Data;
using MovieSystem.MVC.ViewModels;

namespace MovieSystem.MVC.Controllers
{
    public class MoviesController : Controller
    {
        UowData data;

        public MoviesController()
        {
            this.data = new UowData();
        }

        // GET: /Movies/
        public ActionResult Index(int? id)
        {
            if (Request.IsAjaxRequest())
            {
                var movie = data.Movies.All()
                    .FirstOrDefault(x => x.MovieId == id);
               
                return View(movie);
            }

            return View(data.Movies.All().ToList());
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = data.Movies.All().FirstOrDefault(x => x.MovieId == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_MovieDetails", movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            return PartialView("_AddForm");
        }

        // POST: /Movies/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                data.Movies.Add(movie);
                data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = data.Movies.All().FirstOrDefault(x => x.MovieId == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditForm",movie);
        }

        // POST: /Movies/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.data.Movies.Update(movie);
                data.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_EditForm", movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = data.Movies.All().FirstOrDefault(x => x.MovieId == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = data.Movies.All().FirstOrDefault(x => x.MovieId == id);
            data.Movies.Delete(movie);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            data.Dispose();
            base.Dispose(disposing);
        }


        protected ActionResult GetAllMovies()
        {
            var movies = data.Movies.All().ToList();
            return PartialView("_MovieList", movies);
        }
    }
}
