using AngularPruebaClip.Models;
using AngularPruebaClip.Models.Common;
using AngularPruebaClip.Models.Request;
using AngularPruebaClip.Models.Response;
using AngularPruebaClip.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AngularPruebaClip.Services
{
    public class VerificacionService : IVerificacionService
    {

        private readonly MyDBContext db;
        private readonly AppSettings _appSettings;

        public VerificacionService(IOptions<AppSettings> appSettings, MyDBContext context)
        {
            _appSettings = appSettings.Value;
            db = context;
        }

        
        public VerificacionResponse Auth(AuthRequest model)
        {

            VerificacionResponse verificarResponse = new VerificacionResponse();
            using (db)
            {
                string Scontraseña = Encrypt.GetSHA256(model.Contraseña);

                var NombreUsuario = db.Cliente.Where(d => d.NombreUsuario == model.NombreUsuario &&
                                                     d.Contraseña == Scontraseña).FirstOrDefault();

                if (NombreUsuario == null)
                {
                    return null;
                }
                verificarResponse.NombreUsuario = NombreUsuario.NombreUsuario;
                verificarResponse.Token = GetToken(NombreUsuario);
            }

            return verificarResponse;
            
        }

        private string GetToken(Cliente cliente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] 
                    {
                        new Claim(ClaimTypes.NameIdentifier, cliente.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, cliente.Contraseña)
                    }
                    ),
                    Expires = DateTime.UtcNow.AddDays(60),
                    SigningCredentials = 
                    new SigningCredentials(new SymmetricSecurityKey (llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
