
using SisGobernance.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SisGobernance.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Empresa { get; set; }
        [Required]        
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }        

        [Required]
        public RolEmun Rol { get; set; }

        public virtual List<Formulario>? Formularios { get; set; }
    }
}
