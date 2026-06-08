using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    [Table("Marca")]
    public class MarcaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la marca es requerido")]
        [Display(Name = "Nombre de la Marca")]
        public string NombreMarca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El país de origen es requerido")]
        [Display(Name = "País de Origen")]
        public string PaisOrigen { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de registro es requerida")]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        public ICollection<VehiculoModel>? Vehiculos { get; set; }
    }
}
