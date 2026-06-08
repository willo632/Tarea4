using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    [Table("Matricula")]
    public class MatriculaModel
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de emisión es requerida")]
        [Display(Name = "Fecha de Emisión")]
        public DateTime FechaEmision { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un vehículo")]
        [Display(Name = "Vehículo")]
        public int VehiculoId { get; set; }
        public VehiculoModel? Vehiculo { get; set; }
    }
}
