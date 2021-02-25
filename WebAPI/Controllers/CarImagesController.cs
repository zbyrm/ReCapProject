using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    

    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnviroment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnviroment = webHostEnvironment;
        }
         
        private bool fileUpload(FileUpload objectFile, string fileName)
        {
            try
            {
                if (objectFile.files.Length > 0)
                {
                    string path = _webHostEnviroment.WebRootPath + @"\uploads\CarImages\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = System.IO.File.Create(path + fileName))
                    {
                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return true;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }          


        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int carId, [FromForm] FileUpload objectFile)
        {
            string fileExtension = Path.GetExtension(objectFile.files.FileName);
            string newFileName = Guid.NewGuid().ToString() + fileExtension;

            if (_carImageService.CheckIfCarImageCountOfCarCorrect(carId).Success)
            {
                if (fileUpload(objectFile, newFileName))
                {

                    CarImage carImage = new CarImage();
                    carImage.CarId = carId;
                    carImage.ImagePath = newFileName;
                    carImage.Date = DateTime.Now.Date;
                    var result = _carImageService.Add(carImage);
                    if (result.Success)
                    {
                        return Ok(result);
                    }

                }
                return BadRequest("dosya yuklenemedi");
            }
            else
            {
                return BadRequest("Bir araç için 5 resim ekleye bilirsiniz...");
            }
             

        }

    
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
