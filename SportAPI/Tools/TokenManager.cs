using Microsoft.IdentityModel.Tokens;
using SportAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportAPI.Tools
{
    public class TokenManager
    {
        public static string secretKey = "MFDkEVpTwGVdslDyRocJXvKjpVFjSaIHkHUbNKGOqasMyfNaSJzVTQEwQfgxMXBahrpvCKpBPKjBKeyuZdkLSHCZEuWESCWoObESEwJIZwoISBdlhmTUMAgaZUrOyCDs!";
        public static string issuer = "BeastWorkout";
        public static string audience = "myapidomain.com";
        public static string GenerateJWT(Person person, IConfiguration configuration, List<string> Roles=null)
        {
            // 1 - Instanciation de l'objet permettant de créer le Token après configuration
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();

            //2- Récupérer la clé de signature
            Byte[] SigningKey = Encoding.UTF8.GetBytes(configuration["jwt:key"]);

            //3- Composition de mon token via un Descripteur de sécurité
            //3.1 Récupération des rôles et ajout dans l'objet claimIdenity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            foreach (string item in Roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, item));
            }
            //3.2 Ajout des autres claims
            claimsIdentity.AddClaims(new List<Claim>
                    {
                        //3.4.1 GUID qui identifie de manière notre token pour éviter le "replay"
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //3.4.2 Custom Claim
                        new Claim("Id", person.Id.ToString()),
                        //3.4.3 Ajout du nom dans les claims
                        new Claim(JwtRegisteredClaimNames.FamilyName, person.Firstname),
                        //3.4.4 Ajout de l'email
                        new Claim(JwtRegisteredClaimNames.Email, person.Mail)

                    });
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                //3.3 La signature basée sur la clé
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SigningKey),
                                                           SecurityAlgorithms.HmacSha512),

                //3.4 Date D'expiration
                Expires = DateTime.Now.AddMinutes(30),

                //3.5 issuer et l'audience
                Issuer = configuration["jwt:issuer"],
                Audience = configuration["jwt:audience"],

                //3.6 Ajout Payload (Claims) suivant vos besoins :)
                Subject = claimsIdentity
            };

            //4 - Générer le token de sécurité
            SecurityToken token = jwtHandler.CreateToken(tokenDescriptor);

            //5 - Ecriture du Token en string
            string strJWT = jwtHandler.WriteToken(token);

            //6 - On retourne le token 
            return strJWT;
        }
    }
}
