using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    [Table("Propietario")]
    public class PropietarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Los nombres son requeridos")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es requerida")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        public ICollection<VehiculoModel>? Vehiculos { get; set; }
    }
}
