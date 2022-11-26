using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Business.HttpClients;
using GenericRepositoryDemo.Domain.Entities;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        UserClient _client;
        public UsersController(IUserService userService, UserClient client)
        {
            _userService = userService;
            _client = client;
        }

        // this method fetches data from API and adds data to the database.
        [HttpPost]
        public IActionResult Post()
        {
            var cronTime = "*/5 * * * * *";
            RecurringJob.AddOrUpdate(() =>_client.GetUser(), cronTime);
            return  Ok();
        }

        // this method fetches data from the database
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var result = await _userService.GetAll();
            return Ok(result);
        }
    }
}
