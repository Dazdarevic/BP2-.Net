using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Domain.Identity;
using NBP.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NBP.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext dc;

        private readonly IConfiguration _configuration;

        public LoginRepository(DataContext dataContext, IConfiguration configuration)
        {
            this.dc = dataContext;
            this._configuration = configuration;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Pretvori lozinku u bajtovni niz
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Konvertuj bajtove u string u heksadecimalnom formatu
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public async Task<IActionResult> PostLoginDetails(UserData _userData)
        {
            if (_userData != null)
            {
                User user;

                var resultLoginCheck = dc.Administrators
                    .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                    .FirstOrDefault();
                var resultLoginCheck2 = dc.Managers
                    .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                    .FirstOrDefault();
                var resultLoginCheck3 = dc.Members
                        .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                        .FirstOrDefault();
                var resultLoginCheck4 = dc.Receptionists
                        .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                        .FirstOrDefault();
                var resultLoginCheck5 = dc.Sellers
                        .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                        .FirstOrDefault();
                var resultLoginCheck6 = dc.Sponsors
                        .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                        .FirstOrDefault();
                var resultLoginCheck7 = dc.Trainers
                        .Where(e => e.Email == _userData.Email && e.Password == EncryptPassword(_userData.Password))
                        .FirstOrDefault();

                switch (true)
                {
                    case object when resultLoginCheck != null:
                        user = resultLoginCheck;
                        break;
                    case object when resultLoginCheck2 != null:
                        user = resultLoginCheck2;
                        break;
                    case object when resultLoginCheck3 != null:
                        user = resultLoginCheck3;
                        break;
                    case object when resultLoginCheck4 != null:
                        user = resultLoginCheck4;
                        break;
                    case object when resultLoginCheck5 != null:
                        user = resultLoginCheck5;
                        break;
                    case object when resultLoginCheck6 != null:
                        user = resultLoginCheck6;
                        break;
                    case object when resultLoginCheck7 != null:
                        user = resultLoginCheck7;
                        break;
                    default:
                        return BadRequest("Invalid Credentials");
                }

                var refreshToken = GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                await dc.SaveChangesAsync();
                //_userData.UserMessage = "Login Success";

#pragma warning disable CS8604 // Possible null reference argument.
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserEmail", _userData.Email),
                        new Claim("UserRole", user.Role),
                        new Claim("UserName", user.FirstName +" "+ user.LastName),
                        new Claim("UserPassword", _userData.Password),
                        new Claim("UserId", user.ID.ToString())
                    };
#pragma warning restore CS8604 // Possible null reference argument.


#pragma warning disable CS8604 // Possible null reference argument.
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
#pragma warning restore CS8604 // Possible null reference argument.
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn);


                _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);


                UserDto userDto = new UserDto(new JwtSecurityTokenHandler().WriteToken(token), user.RefreshToken, user.UserName,
                    user.Role, user.ID);

                return new JsonResult(userDto);

                //return new JsonResult(response);
            }
            else
            {
                return new JsonResult("hej :)");
            }
        }

        private IActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}
