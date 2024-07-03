using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public UserController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var appUser = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (!createUser.Succeeded)
                {
                    return StatusCode(500, createUser.Errors);
                }
                
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                
                if (!roleResult.Succeeded)
                {
                    return StatusCode(500, roleResult.Errors);
                }
                
                return Ok(
                    new NewUserDto{
                        UserName = appUser.UserName, 
                        Email = appUser.Email,
                        Token = _tokenService.CreateToken(appUser)
                    }
                );
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}