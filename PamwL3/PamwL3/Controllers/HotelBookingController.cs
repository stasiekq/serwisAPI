using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PamwL3.Models;
using PamwL3.Data;

namespace PamwL3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            var response = new ServiceResponse();

            if(!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid data";
                response.Errors =  response.Errors = 
                    new List<string>(ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
                return new JsonResult(BadRequest(response));
            }


            if(booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if(bookingInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                bookingInDb = booking;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);
            var response = new ServiceResponse();

            if(!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid data";
                response.Errors =  response.Errors = 
                    new List<string>(ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
                return new JsonResult(BadRequest(response));
            }

            if(result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);
            var response = new ServiceResponse();

            if(!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid data";
                response.Errors =  response.Errors = 
                    new List<string>(ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
                return new JsonResult(BadRequest(response));
            }

            if(result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
