using AngularPruebaClip.Models.Request;
using AngularPruebaClip.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPruebaClip.Services
{
    public interface IVerificacionService
    {
        VerificacionResponse Auth(AuthRequest model);
    }
}
