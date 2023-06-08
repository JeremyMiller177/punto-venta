using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoVenta.Models
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
            
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string Contrasena { get; set; }

        public ICollection<VentaEncabezado>? VentaEncabezados { get; }

#pragma warning disable CS8618
        public Usuario() { }

        public Usuario(string nombre, string correo, string contrasena)
        {
            Nombre = nombre;
            Correo = correo;
            Contrasena = contrasena;
        }
    }
}
