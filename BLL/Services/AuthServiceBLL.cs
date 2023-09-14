using BLL.Models;
using BLL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServiceBLL : IAuthRepositoryBLL
    {
        private readonly IConfiguration _configuration;
        private readonly IPersonRepositoryBLL<PersonBLL> _personRepositoryBLL;

        public AuthServiceBLL(IConfiguration configuration, IPersonRepositoryBLL<PersonBLL> personRepositoryBLL)
        {
            _configuration = configuration;
            _personRepositoryBLL = personRepositoryBLL;
        }

        public async Task<string> GenerateJwtToken(LoginBLL login)
        {
            PersonBLL person = _personRepositoryBLL.Login(login);
            if (person == null)
            {
                throw new ArgumentException("Login or password incorrect");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, login.Login),
            new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()) // Ajouter la revendication de l'identifiant de l'utilisateur
                    // Ajoutez des revendications supplémentaires ici si nécessaire
                }),
                //Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationInMinutes"])),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Vérifiez si la personne a le rôle "Admin" (Id_type_person = 1)
            if (person.Id_type_person == 1)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
