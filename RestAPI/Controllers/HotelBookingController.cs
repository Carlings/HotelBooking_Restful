using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Data;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public HotelBookingController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking hotelBooking)
        {
            if(hotelBooking.Id == 0)
            {
                _dbContext.Bookings.Add(hotelBooking);
            }
            else
            {
                var bookingInDb = _dbContext.Bookings.Find(hotelBooking);
                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = hotelBooking;
            }
            _dbContext.SaveChanges();

            return new JsonResult(Ok(hotelBooking));
        }
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _dbContext.Bookings.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _dbContext.Bookings.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

            _dbContext.Bookings.Remove(result);
            _dbContext.SaveChanges();

            return new JsonResult(NoContent());
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _dbContext.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
