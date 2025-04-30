using Microsoft.AspNetCore.Mvc;
using modul10_103022300107;
using System;
namespace modul10_103022300107.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<string> stars = new List<string>
         {
            new string("Tim RobbinsMorgan"),
            new string("morgan freeman"),
             new string("Bob Gunton"),
                new string("Marlon Brando"),
                  new string("Al Pacino"),
                     new string("James Caan"),
         };
        private static List<Movie> MovieList = new List<Movie> 
        {
            new Movie("The Shawshank Redemption", "Joseph Kosinski", stars, "After more than thirty years of service as one of the Navy's top aviators, Pete \"Maverick\" Mitchell is where he belongs, pushing the envelope as a courageous test pilot and dodging the advancement in rank that would ground him."),
               new Movie("The Godfather", "\r\nFrancis Ford Coppola", stars, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),

        };
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieList;
        }
        [HttpGet("{index}")]
        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= MovieList.Count)
                return NotFound();
            return MovieList[index];
        }
        [HttpPost]
        public ActionResult Post([FromBody] Movie Movie)
        {
            MovieList.Add(Movie);
            return CreatedAtAction(nameof(Get), new
            {
                index = MovieList.Count -
           1
            }, Movie);
        }
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= MovieList.Count)
                return NotFound();
            MovieList.RemoveAt(index);
            return NoContent();
        }
    }
}

