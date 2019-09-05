using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelCalifornia.Domain.ErrorHandling;
using HotelCalifornia.Domain.Storages;
using HotelCalifornia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelCalifornia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AccountStorage _storage;

        public AccountController(
            AccountStorage storage)
        {
            _storage = storage;
        }
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">RegisterViewModel</param>
        /// <returns>null if the operation was successfull</returns>
        /// <response code="204">The server successfully processed the register request, but is not returning any content</response>
        [HttpPost("register")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> Register(RegisterViewModel model)
        {
            return await _storage.Register(model);
        }

        /// <summary>
        /// Logs in to the system.
        /// </summary>
        /// <param name="model">LoginViewModel</param>
        /// <returns>null if the operation was successfull</returns>
        /// <response code="204">The server successfully processed the login request, but is not returning any content</response>
        [HttpPost("login")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> Login(LoginViewModel model)
        {
            return await _storage.Login(model);
        }

        /// <summary>
        /// Logs out of the system.
        /// </summary>
        /// <returns>null</returns>
        /// <response code="204">The server successfully processed the logout request, but is not returning any content</response>
        [HttpGet("logout")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> Logout()
        {
            return await _storage.Logout();
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
