using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservatie.API.Models;
using Reservatie.Core.Models;
using Reservatie.Core.Repositories;

namespace Reservatie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;
        public MoviesController(IMovieRepo movieRepo, ILogger<MoviesController> logger)
        {
            this._movieRepo = movieRepo;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string name = null)
        {
            var model = await _movieRepo.GetMoviesAsync();
            Movies_DTO model_DTO = new Movies_DTO();
            foreach(Movie movie in model)
            {
                MovieMapper.ConvertTo_DTO(movie,model_DTO);
            }
            
            return Ok(model_DTO);
        }
    }
}