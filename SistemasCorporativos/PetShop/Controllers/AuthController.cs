using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetShop.Models;
using PetShop.Repositories;



namespace PetShop.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IConfiguration _config;

        public AuthController(IFuncionarioRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        //login
        [HttpPost("login")]
        public ActionResult Login([FromBody] Funcionario login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Senha))
            return BadRequest("Email e senha são obrigatórios");

            var user = _repository.BuscarPorEmail(login.Email);
            if (user == null || user.Senha != login.Senha)
            return Unauthorized("Usuário ou senha inválidos");

            if (user.Cargo != Role.Gerente)
            return Unauthorized("Acesso permitido apenas para gerentes");

            var Claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Cargo.ToString())
            };

            var secretKey = _config["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: Claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new{ Token = tokenString});
        }
    }
}