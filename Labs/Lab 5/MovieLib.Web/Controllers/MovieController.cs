using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieLib.Data.Sql;
using MovieLib.Web.Models;

namespace MovieLib.Web.Controllers
{    
    [DescriptionAttribute("Handles movie requests")]    
    public class MovieController : Controller
    {        
        public MovieController ( ) : this(GetDatabase())
        {
        }

        public MovieController ( MovieDatabase database )
        {
            _database = database;
        }
		
		/// <summary> Adds Movie to the web </summary>
        /// <param name="model"> Movie to be added to the web </param>
        /// <returns> Movie added to the web </returns>
        [HttpPost]
        public ActionResult Add ( MovieViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Add(model.ToDomain());

                    return RedirectToAction("List");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }
		
		/// <summary> Deletes Movie from webserver </summary>
        /// <param name="id"> ID of movie to be deleted from the webserver </param>
        /// <returns> Movie deleted from the webserver </returns>
        public ActionResult Delete ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie.ToModel());
        }
		
		/// <summary> Deletes Movie from webserver </summary>
        /// <param name="model"> Movie to be deleted from the webserver </param>
        /// <returns> Movie deleted from the webserver </returns>
        [HttpPost]
        public ActionResult Delete ( MovieViewModel model )
        {
            try
            {
                _database.Remove(model.Id);

                return RedirectToAction("List");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };            

            return View(model);
        }
		
		/// <summary> Edits Movie from webserver </summary>
        /// <param name="id"> ID of movie to be edited from the webserver </param>
        /// <returns> Movie edited </returns>
        public ActionResult Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie.ToModel());
        }
		
		/// <summary> Edits Movie from webserver </summary>
        /// <param name="movie"> Movie to be Edited from the webserver </param>
        /// <returns> Movie Edited from the webserver </returns>
        [HttpPost]
        public ActionResult Edit ( MovieViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.ToDomain());

                    return RedirectToAction("List");
                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }
		
		/// <summary> Gets list of Movies from webserver </summary>
        /// <returns> Movie list </returns>
        public ActionResult List()
        {
            var movies = _database.GetAll();

            return View(movies.ToModel());
        }
		
		/// <summary> Gains access to the local database </summary>
        /// <returns> Local database </returns>
        private static MovieDatabase GetDatabase ()
        {
            var connstring = ConfigurationManager.ConnectionStrings["MovieDatabase"];

            return new sqlMovieDatabase(connstring.ConnectionString);
        }
        
		private MovieDatabase _database;
    }
}