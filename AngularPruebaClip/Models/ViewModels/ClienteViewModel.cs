using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPruebaClip.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Cuil { get; set; }
        public byte[] Foto { get; set; }
        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }
    }
}
