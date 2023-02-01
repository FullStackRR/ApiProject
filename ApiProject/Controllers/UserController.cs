using AutoMapper;
using DataLayer;
using DTO;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPasswordService _passwordService;

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper,IPasswordService passwordService)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        // GET: api/<UserControler>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWithOutPasswordDTO>>> Get([FromQuery]string email, [FromQuery] string password)
        {

         //throw new NotImplementedException();

          _logger.LogInformation("tried to login");
            User? theUser = await _userService.GetUser(email, password);
            if (theUser != null) {
                UserWithOutPasswordDTO user = _mapper.Map<User, UserWithOutPasswordDTO>(theUser);
                return Ok(new List<UserWithOutPasswordDTO>() { user });
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
        public async Task<ActionResult<UserWithOutPasswordDTO>> Post([FromBody] UserDTO newUser)
        {
            User user = _mapper.Map<UserDTO, User>(newUser);

            int level = _passwordService.CheckPassword(user.Password);
            if(level <4)
            {
                return BadRequest();
            }
            User userAdded = await _userService.Post(user);
            if(userAdded!=null)
            {
                UserWithOutPasswordDTO userToReturn = _mapper.Map<User,UserWithOutPasswordDTO>(userAdded);

                return CreatedAtAction(nameof(Get), new { id = user.Id }, userToReturn);
            }
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
