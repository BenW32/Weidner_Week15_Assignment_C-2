using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Group2_CompRepair;
using Group2_CompRepair.Models;
using Group2_CompRepair.Data;
using Group2_CompRepair.Controllers;


namespace Group2_CompRepair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public AuthenticationController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.username, usr.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [Authorize]
        [Route("TestRoute")]
        [HttpGet]
        public IActionResult test()
        {
            return Ok("Authorized");
        }

        /*[Authorize]
        [Route("Route1")]
        [HttpGet]
        public IActionResult test1()
        {
            return Ok("This is route 1");
        }

        [Authorize]
        [Route("Route2")]
        [HttpGet]
        public IActionResult test2()
        {
            return Ok("This is route 2");
        }

        [Authorize]
        [Route("Route3")]
        [HttpGet]
        public IActionResult test3()
        {
            return Ok("This is route 3");
        }
        [Authorize]
        [Route("Route4")]
        [HttpGet]
        public IActionResult test4()
        {
            return Ok("This is route 4");
        }
        [Authorize]

        [Route("Route5")]
        [HttpGet]
        public IActionResult test5()
        {
            return Ok("This is route 5");
        }

        */
    }
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}