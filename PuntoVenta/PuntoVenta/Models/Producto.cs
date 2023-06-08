using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PuntoVenta.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(256)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        public int TipoProductoId { get; set; }

        [ForeignKey("TipoProductoId")]
        public TipoProducto? TipoProducto { get; set; }

        public virtual List<VentaDetalle>? VentaDetalles { get; set; } = new List<VentaDetalle>();

#pragma warning disable CS8618
        public Producto() { }

        public Producto(string nombre, int stock, decimal precio, int tipoProductoId)
        {
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
            TipoProductoId = tipoProductoId;
        }
    }
}
