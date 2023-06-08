using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PuntoVenta.Models
{
    public class VentaDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "El subtotal es requerido")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "El encabezado es requerido")]
        public int VentaEncabezadoId { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        public int ProductoId { get; set; }

        [ForeignKey("VentaEncabezadoId")]
        public VentaEncabezado? VentaEncabezado { get; set; }

        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }
    }
}
