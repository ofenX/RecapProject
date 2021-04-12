using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
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
            var result = _carService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(int min,int max)
        {
            var result = _carService.GetByDailyPrice(min,max);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getcarsdetail")]
        public IActionResult GetCarsDetail()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }
        [SecuredOperation("car.add,admin")]
        [HttpPost("add")]
        public IActionResult Add(Car car)

        {
            var result = _carService.Add(car);


            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)

        {
            Car carToUpdate;
            carToUpdate = car;
            var result = _carService.Update(carToUpdate);


            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)

        {
            
            //var carToDelete = car;
            var result = _carService.Delete(car);


            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }





    }
}
