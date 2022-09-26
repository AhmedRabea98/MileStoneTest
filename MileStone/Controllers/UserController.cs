using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MileStone.Context;
using MileStone.DTO;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MileStone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration configuration;
        private readonly DBContext context;
        public UserController(UserManager<User> _userManager , IConfiguration configuration, DBContext context)
        {
            this._userManager = _userManager;
            this.configuration = configuration;
            this.context = context;
        }

      /*  [Authorize]*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await context.Users.ToListAsync();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User userEmail = await _userManager.FindByEmailAsync(registerDTO.Email);
            User userName = await _userManager.FindByNameAsync(registerDTO.UserName);

            if (userEmail != null )
            {
                return BadRequest("Email Exists");
            }
            if(userName != null)
            {
                return BadRequest("UserName Exists");
            }
            User userModel = new User();
            userModel.Email = registerDTO.Email;
            userModel.UserName = registerDTO.UserName;
            userModel.Status = registerDTO.Status;
            userModel.Skills = registerDTO.Skills;
            userModel.PassportNumber = registerDTO.PassportNumber;
            userModel.PassportExpiryDate = registerDTO.PassportExpiryDate;
            userModel.JoiningDate = registerDTO.JoiningDate;
            userModel.IqamaExpiryDate = registerDTO.IqamaExpiryDate;
            userModel.ContractRenewalDate = registerDTO.ContractRenewalDate;
            userModel.FirstName = registerDTO.FirstName;
            userModel.LastName = registerDTO.LastName;
            userModel.Position = registerDTO.Position;
            IdentityResult result = await _userManager.CreateAsync(userModel, registerDTO.Password);
            if (result.Succeeded)
            {
                return Ok("You Registered Successfully");
            }
            else
            {
                foreach (var i in result.Errors)
                {
                    ModelState.AddModelError("", i.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO logInDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = await _userManager.FindByEmailAsync(logInDTO.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, logInDTO.Password))
                {

                    var claims = new List<Claim>();
                    claims.Add(new Claim("ITI42", "Zagazig"));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.PassportNumber));

                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                    var mytoken = new JwtSecurityToken(

                        audience: configuration["JWT:ValidAudience"],
                        issuer: configuration["JWT:ValidIssuer"],
                        expires: DateTime.Now.AddMonths(12),
                        claims: claims,
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                            key, SecurityAlgorithms.HmacSha256));
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                        expiration = mytoken.ValidTo
                    });

                }
                else
                {
                    return Unauthorized();
                }



            }
            return Unauthorized();
        }

    }
}
