using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IdeVerseContracts;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace RBCAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfigurationManager _configurationManager;
        private IUserService _userService;
        public LoginController(IConfigurationManager configurationManager, IUserService userService) 
        {
            _configurationManager = configurationManager;
            _userService = userService;
        }

        [AllowAnonymous]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.GetUserByLogin(loginDto);
            if (user == null) 
            {
                return Unauthorized("Пользователь не найден");
            }
            var rights = new List<string>();
            if (user.Role != null && user.Role.Rights != null && user.Role.Rights.Any())
            {
                rights = user.Role.Rights.Select(x => x.Mnemo).ToList();
            }
            var tokenString = GenerateJSONWebToken(loginDto, user.Id, JsonSerializer.Serialize(rights, typeof(List<string>)));
           
            return Ok(new Identity()
            {
                Login = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString,
                Rights = rights
            });
        }

        private string GenerateJSONWebToken(LoginDto loginDto, Guid userId, string rights)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationManager.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] { 
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString(), ClaimValueTypes.String), 
                new Claim(ClaimsIdentity.DefaultRoleClaimType, rights.ToString(), ClaimValueTypes.String) 
            };
            var token = new JwtSecurityToken(_configurationManager.JwtIssuer,
                _configurationManager.JwtIssuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
 
    }
}