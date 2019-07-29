using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
//using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BettyAppAPI.Dtos;
using BettyAppAPI.Helpers;
using BettyAppAPI.Models;
using BettyAppAPI.Services;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettyAppAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        //private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper
           // IOptions<AppSettings> appSettings
           )
        {
            _userService = userService;
            _mapper = mapper;
            //_appSettings = appSettings.Value;
        }

       
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userDto)
        {
            var user = _userService.Authenticate(userDto.email, userDto.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
           /* var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);*/

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                id = user.id,
                email = user.email,
                firstname = user.firstname,
                lastname = user.lastname,
                occupation = user.occupation,
                gender = user.gender,
                //dob = user.dob,
                nationality = user.nationality,
                contact_no = user.contact_no,
                residentialAddress = user.residentialAddress
                //Token = tokenString
            });
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody]User user)
        {
            // map dto to entity
            //var user = _mapper.Map<User>(userDto);
            try
            {
                // save 
                Console.WriteLine("The users id is: " + user.id);
                _userService.Create(user, user.password);
                return Ok(user);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]User user)
        {
            // map dto to entity and set id
            //var user = _mapper.Map<User>(userDto);
        
            user.id = id;

            try
            {
                // save 
                _userService.Update(user, user.password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
