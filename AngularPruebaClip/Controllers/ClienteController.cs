using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularPruebaClip.Models.Response;
using AngularPruebaClip.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace AngularPruebaClip.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private  Models.MyDBContext db;

        public ClienteController(Models.MyDBContext context)
        {
            db = context;
        }

        /*[HttpGet("[action]")]
        public IEnumerable<ClienteViewModel> Cliente()
        {
            List<Models.Cliente> lst = null;

            lst = db.Cliente.ToList();

            return Json(lst);

        }*/

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ClienteViewModel model)
        {
            MyResponse oR = new MyResponse();

            try
            {
                Models.Cliente cliente = new Models.Cliente();
                cliente.NombreUsuario = model.NombreUsuario;
                cliente.Contraseña = model.Contraseña;
                cliente.Nombre = model.Nombre;
                cliente.Apellido = model.Apellido;
                cliente.Dni = model.Dni;
                cliente.Domicilio = model.Domicilio;
                cliente.CorreoElectronico = model.CorreoElectronico;
                cliente.Telefono = model.Telefono;
                cliente.Cuil = model.Cuil;
                db.Cliente.Add(cliente);
                db.SaveChanges();
                
                oR.Success = 1;
            }
            catch (Exception ex)
            {

                oR.Success = 0;
                oR.Message = ex.Message;
            }

            return oR;
        }



    }
}