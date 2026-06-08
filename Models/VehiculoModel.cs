using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    [Table("Vehiculo")]
    public class VehiculoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La placa es requerida")]
        [Display(Name = "Placa")]
        public string Placa { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es requerido")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año es requerido")]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una marca")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        public MarcaModel? Marca { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un propietario")]
        [Display(Name = "Propietario")]
        public int PropietarioId { get; set; }
        public PropietarioModel? Propietario { get; set; }

        public ICollection<MatriculaModel>? Matriculas { get; set; }
        public ICollection<RevisionTecnicaModel>? RevisionesTecnicas { get; set; }
    }
}
