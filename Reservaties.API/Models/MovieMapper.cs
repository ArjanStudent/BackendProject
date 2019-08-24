using Reservatie.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservatie.API.Models
{
    public class MovieMapper
    {
        public static Movies_DTO ConvertTo_DTO(Movie movie, Movies_DTO movie_DTO)
        {
            movie_DTO.Description = movie.Description;
            movie_DTO.Title = movie.Title;
            movie_DTO.Duration_Movie = movie.Duration_Movie;
            movie_DTO.Director = movie.Director;

            return movie_DTO;
        }
    }
}
