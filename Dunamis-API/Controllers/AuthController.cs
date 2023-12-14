using Dunamis_API.Data;
using Dunamis_API.Model.Dtos.Usuarios;
using Dunamis_API.Model.Model.Dtos.Usuarios;
using Dunamis_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Usuario user = new Usuario();
        private readonly IConfiguration _configuration;
        // private readonly IUserService _userService;
        private readonly DataContext _context;
        

        public AuthController(IConfiguration configuration, DataContext context)
        {
            _context = context;
            _configuration = configuration;

            //  _userService = userService;
        }



        [HttpPost("register")]
        //// [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if (_context.Usuario.Any(u => u.Email == request.Email))
            {
                return BadRequest("Usuario ja existe na base de dados.");
            }
            if (_context.Usuario.Any(u => u.Username == request.Username))
            {
                return BadRequest("Usuario ja existe na base de dados.");
            }

            CreatePasswordHash(request.Password,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var user = new Usuario
            {
                Email = request.Email,
                Username = request.Username,
                NomeCompleto = request.NomeCompleto,
                Status = request.Status,
                Funcao = request.Funcao,
                Telefone = request.Telefone,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                // VerificationToken = CreateRandomToken()
            };

            _context.Usuario.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { data = user.Id,
                resposta = "Usuário criado com sucesso!" });
        }


      

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {
            var user = await _context.Usuario.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Usuario ou senha incorretos.");
            }


            await _context.SaveChangesAsync();

            string token = CreateToken(user);


            return Ok(new
            {
                id = user.Id,
                Username = user.Username,
                NomeCompleto = user.NomeCompleto,
                Status = user.Status,
                Email = user.Email,
                Telefone = user.Telefone,

                token
            });
        }

    


        [HttpPost("refresh-token")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);


            return Ok(token);
        }

       


        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResettPassword(ResetPasswordRequest request)
        {
            var user = await _context.Usuario.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            //if (user == null || user.ResetTokenExpires < DateTime.Now)
            //{
            //    return BadRequest("Token inválido.");
            //}

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();

            return Ok(new { resposta = "Senha alterada com sucesso.", data = user.Username });
        }


        [HttpPost("alterar-senha")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(int id, string currentPassword, string newPassword)
        {
            var user = await _context.Usuario.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (!VerifyPasswordHash(currentPassword, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Senha atual incorreta.");
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return Ok("Senha alterada com sucesso.");
        }





        private string CreateToken(Usuario user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,

                expires: DateTime.Now.AddHours(10),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
