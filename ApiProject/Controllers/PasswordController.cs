using Microsoft.AspNetCore.Mvc;
using Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        public PasswordController(IPasswordService passwordService)
        {
            this._passwordService = passwordService;

        }
     


        // POST api/<PasswordController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            //throw new Exception();
           return Ok(this._passwordService.CheckPassword(password));

        }

       
   
    }
}
