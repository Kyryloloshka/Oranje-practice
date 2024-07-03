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
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
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
    
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());
                if (user == null)
                {
                    return Unauthorized("Invalid email");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (!result.Succeeded)
                {
                    return Unauthorized("Email or password is incorrect");
                }

                return Ok(
                    new NewUserDto{
                        UserName = user.UserName, 
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
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