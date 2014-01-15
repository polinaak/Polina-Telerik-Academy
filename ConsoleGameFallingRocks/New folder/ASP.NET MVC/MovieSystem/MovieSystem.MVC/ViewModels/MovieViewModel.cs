using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieSystem.MVC.ViewModels
{
    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get 
            {
                return movie => new MovieViewModel
                    {
                        Title = movie.Title,
                        Director = movie.Director,
                        MovieId = movie.MovieId,
                        FemaleRole = movie.LeadingRoles.FemaleRole,
                        MaleRole = movie.LeadingRoles.MaleRole,
                        Studio = movie.Studio.StudioAddress,
                        Year = movie.Year,
                    };
            }
        }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public string Studio { get; set; }

        public string FemaleRole { get; set; }

        public string MaleRole { get; set; }
    }
}