using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        ICarService _carService;

        public CarImagesController(ICarImageService carImageService, ICarService carService)
        {
            _carImageService = carImageService;
            _carService = carService;

        }

       
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage,[FromForm(Name = "Image")] IFormFile file)
        {

            var result = _carImageService.Add(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)

        {
            var carImageToDelete = _carImageService.Get(id).Data;

            var result = _carImageService.Delete(carImageToDelete);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImages = _carImageService.Get(Id).Data;
            var result = _carImageService.Update(carImages, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int id)
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbycarid")]
        public IActionResult Get([FromForm(Name = ("Id"))] int id)
        {
           
                var result = _carImageService.GetByCarId(id);
                if (result.Success)
                {
                    return Ok(result);

                } 
               
                return BadRequest(result);
          
        }

        [HttpGet("getcarimagebycaridj")]
        public IActionResult GetImageByCarId([FromForm(Name = ("Id"))] int id)
        {


            var result = _carImageService.GetCarImageByCarId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }



    }






}
