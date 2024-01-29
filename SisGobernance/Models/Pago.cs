using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisGobernance.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Fecha { get; set; }
        [Required]
        public string? Monto { get; set; }

        public string? Foto { get; set; }

        //para manejo de archivos
        [NotMapped]
        [Display(Name = "Cargar Comprobante")]
        public IFormFile? FotoFile { get; set; }

        public int FormularioId { get; set; }
        public virtual Formulario? Formulario { get; set; }



    }
}
