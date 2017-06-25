using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicStore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class AccountController : Controller
    {
        private List<User> people = new List<User>
        {
            new User { Login="admin", Password="12345", Role = "admin" },
            new User { Login="user", Password="55555", Role = "user" }
        };

        [HttpPost("/token")]
        public async Task Token([FromBody]Credentials credentials)
        {
            try
            {
                var username = credentials.Username;
                var password = credentials.Password;

                var identity = GetIdentity(username, password);
                if (identity == null)
                {
                    Response.StatusCode = 400;
                    await Response.WriteAsync("Invalid username or password.");
                    return;
                }

                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name
                };

                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User user = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }

    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
