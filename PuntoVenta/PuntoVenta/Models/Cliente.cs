using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoVenta.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(256)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Phone]
        [StringLength(50)]
        public string Telefono { get; set; }

        public ICollection<VentaEncabezado>? VentaEncabezados { get; }

#pragma warning disable CS8618
        public Cliente() { }

        public Cliente(string nombre, string direccion, string telefono)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
