using SDRestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SDRestaurantRaterAPI.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // POST
        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Restaurant restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);

            if (restaurant == null)
            {
                return BadRequest($"The target restaurant with the Id of {model.RestaurantId} does not exist.");
            }

            _context.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You rated {restaurant.Name} successfully.");
            }

            return InternalServerError();
        }

        // GET Rating by RestaurantId

        // GET All Ratings

        // PUT
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRating(int id, Rating updatedRating)
        {
            if (ModelState.IsValid)
            {
                Rating rating = await _context.Ratings.FindAsync(id);

                if (rating != null)
                {
                    rating.FoodScore = updatedRating.FoodScore;
                    rating.EnviromentScore = updatedRating.EnviromentScore;
                    rating.CleanlinessScore = updatedRating.CleanlinessScore;

                    await _context.SaveChangesAsync();
                    return Ok("Rating updated successfully.");
                }
                return NotFound();
            }
            return BadRequest();
        }

        // DELETE
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRating(int id)
        {
            Rating rating = await _context.Ratings.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            _context.Ratings.Remove(rating);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The rating was successfully updated.");
            }

            return InternalServerError();
        }
    }
}
