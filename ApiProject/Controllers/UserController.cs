﻿using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;//ui
        private readonly IUserService _userService;
        string filePath = "./users.txt";

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this._userService = userService;
            _logger = logger;
        }

        // GET: api/<UserControler>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromQuery]string email, [FromQuery] string password)
        {

            int x = 4;
            int y = 0;
            try
            {
                x = x / y;
            }
            catch
            {
                _logger.LogError("ccc");

            }

            _logger.LogInformation(email + "tried to login");
            User? theUser = await _userService.GetUser(email, password);
            if (theUser != null)
                return Ok(new List<User>() { theUser });
            else
                return NotFound();
          
        }

        // GET api/<UserControler>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserControler>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User userAdded = await _userService.Post(user);
            if(userAdded!=null)
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            return NotFound();//change to not created!!!!!!!!!!!!!!
        }

        // PUT api/<UserControler>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User theUser)
        {
            _userService.UpdateUser(id, theUser);
            
        }

        // DELETE api/<UserControler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
