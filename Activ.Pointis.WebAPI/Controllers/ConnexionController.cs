using Microsoft.IdentityModel.Tokens;
using Activ.Pointis.WebAPI.Models;
using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace Activ.Pointis.WebAPI.Controllers
{
    public class ConnexionController : ApiController
    {
        [HttpPost]
        [Route("connexion")]
        public IHttpActionResult Connexion(Connexion connexion)
        {
            // validate user credentials
            if (ConnexionModel.IsValidUser(connexion.Login, connexion.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("Activ.Pointis.WebAPI");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, connexion.Login)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return the JWT token as a response
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        // GET: api/Pointage
        [HttpGet]
        public IEnumerable<Connexion> Get()
        {
            return ConnexionModel.afficher();
        }

        // GET: api/Pointage/5
        [HttpGet]
        public IEnumerable<Connexion> Get(long id)
        {
            return ConnexionModel.AfficherUnSeul(id);
        }

        // POST: api/Pointage
        [HttpPost]
        public void Post([FromBody] Connexion connexion)
        {
            ConnexionModel.Ajouter(connexion);
        }

        // PUT: api/Pointage/5
        [HttpPut]
        public void Put(long id, [FromBody] Connexion connexion)
        {
            ConnexionModel.Modifier(id, connexion);
        }

        // DELETE: api/Pointage/5
        [HttpDelete]
        public void Delete(long id)
        {
            ConnexionModel.supprimer(id);
        }
    }
}
