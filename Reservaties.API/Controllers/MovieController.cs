using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservatie.API.Models;
using Reservatie.Models.Repositories;

namespace Reservaties.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;
        public MovieController(IMovieRepo movieRepo, ILogger<MovieController> logger)
        {
            this._movieRepo = movieRepo;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAction([FromQuery]string name = null)
        {
            var model = await _movieRepo.GetMoviesAsync();
            List<Movies_DTO> model_DTO = new List<Movies_DTO>();
            return Ok(model_DTO);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
