using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    [Table("RevisionTecnica")]
    public class RevisionTecnicaModel
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de revisión es requerida")]
        [Display(Name = "Fecha de Revisión")]
        public DateTime FechaRevision { get; set; }

        [Required(ErrorMessage = "El resultado es requerido")]
        [Display(Name = "Resultado")]
        public string Resultado { get; set; } = string.Empty;

        [Required(ErrorMessage = "La observación es requerida")]
        [Display(Name = "Observación")]
        public string Observacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un vehículo")]
        [Display(Name = "Vehículo")]
        public int VehiculoId { get; set; }
        public VehiculoModel? Vehiculo { get; set; }
    }
}
