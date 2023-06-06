using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PuntoVenta.Models
{
    public class TipoProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(256)]
        public string Nombre { get; set; }

        public ICollection<Producto>? Productos { get; }

        #pragma warning disable CS8618
        public TipoProducto() { }

        public TipoProducto(string nombre)
        {
            Nombre = nombre;
        }
    }
}
