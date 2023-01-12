using AutoMapper;
using DataLayer;
using DTO;
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
        private readonly IMapper _mapper;
     
        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<UserControler>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get([FromQuery]string email, [FromQuery] string password)
        {
            try
            {
                int k = 0;
                var x = 4 / k;
            }
            catch
            {
                _logger.LogError("math");
            }
            _logger.LogInformation(email + "tried to login");
            User? theUser = await _userService.GetUser(email, password);
            if (theUser != null) {
                UserDTO user = _mapper.Map<User, UserDTO>(theUser);
                return Ok(new List<UserDTO>() { user });
            }
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
        [HttpPut("{id}")]//this is rivki e
        public async Task Put(int id, [FromBody] User theUser)
        {
            await _userService.UpdateUser(id, theUser);
            
        }


       


        // DELETE api/<UserControler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
