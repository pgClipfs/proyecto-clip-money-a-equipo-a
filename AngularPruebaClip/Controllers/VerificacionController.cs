using AngularPruebaClip.Models.Request;
using AngularPruebaClip.Models.Response;
using AngularPruebaClip.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AngularPruebaClip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificacionController : ControllerBase
    {
        
        private IVerificacionService _userService;

        public VerificacionController(IVerificacionService userService)
        {
            _userService = userService;
            
        }

       


        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {

            MyResponse respuesta = new MyResponse();

            var verificarResponse = _userService.Auth(model);

            if(verificarResponse == null)
            {
                respuesta.Success = 0;
                respuesta.Message = "Usuario o Contraseña incorrecta";
                return BadRequest();
            }
            respuesta.Success = 1;
            respuesta.Data = verificarResponse;

            return Ok(respuesta);
        }
    }
}
