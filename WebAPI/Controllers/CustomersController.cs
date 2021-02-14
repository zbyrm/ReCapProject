﻿using Business.Abstract;
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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerServise;

        public CustomersController(ICustomerService customerServise)
        {
            _customerServise = customerServise;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerServise.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerServise.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerServise.Add(customer);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


    }
}
