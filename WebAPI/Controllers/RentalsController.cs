using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }



        [HttpGet("isrentable")]
        public IActionResult IsRentable(int carId)
        {
            var result = _rentalService.IsRentable(carId);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }





        [HttpPost("add")]
        public IActionResult Add(Rental rental)

        {
            var result = _rentalService.Add(rental);


            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)

        {
            Rental rentalToUpdate;
            rentalToUpdate = rental;
            var result = _rentalService.Update(rentalToUpdate);


            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)

        {


            var result = _rentalService.Delete(rental);


            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }










    }
}
