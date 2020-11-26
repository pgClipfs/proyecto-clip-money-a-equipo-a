using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AngularPruebaClip.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {

        }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

    }

    public class Cliente
    {
        
        public int Id { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [StringLength(10)]
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Cuil { get; set; }
        public byte[] Foto { get; set; }

        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }

    }
}
