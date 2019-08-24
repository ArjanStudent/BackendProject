using Microsoft.AspNetCore.Mvc.Rendering;
using Reservatie.Core.Models;
using Reservatie.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservatie.Web.ViewModels
{
    public class ScreeningMoviesVM
    {
        public ScreeningMoviesVM(IMovieRepo movieRepo, IHallRepo hallRepo, Screening screening)
        {
            this.Screening = screening;
            this.Movie = new SelectList(movieRepo.GetMoviesAsync().Result, "Id", "Title", screening.Movie_Id);
            this.Hall = new SelectList(hallRepo.GetHallsAsync().Result, "Id", "Name", screening.Hall_Id);

        }
        public Screening Screening { get; set; }
        public SelectList Movie { get; set; }
        public SelectList Hall { get; set; }

    }
}
