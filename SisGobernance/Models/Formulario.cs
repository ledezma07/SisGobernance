using SisGobernance.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SisGobernance.Models
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre Del Producto")]
        public string? NombreProducto { get; set; }

        [Required]
        public string? Marca { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        [Display(Name = "Pais de Imortación")]
        public string? Pais { get; set; }
        [Required]
        public int Cantidad { get; set; }

        [Required]
        //[Display(Name = "Pais de Imortación")]
        public string? Observaciones { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }

        [Required]
        public EstadoEmun Rol { get; set; }
        [Required]
        public ElimEmun ElimLog { get; set;}

        public virtual List<Pago>? Pagos { get; set; }

        //Relacion Foranea
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa? Empresa { get; set; }

       



    }
}
