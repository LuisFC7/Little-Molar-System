using System.ComponentModel.DataAnnotations;

namespace LittleMolarApi.Models;

public class PatientDTO{

    [Required(ErrorMessage = "El nombre del paciente es obligatorio.")]
    public required string patientName { get; set; }
    [Required(ErrorMessage = "El apellido del paciente es obligatorio.")]
    public required string patientLastName { get; set; }
    [Required(ErrorMessage = "La edad del paciente es obligatoria.")]
    [Range(0, 100, ErrorMessage = "La edad del paciente no es válida.")]
    public required int patientAge { get; set; }
    [Required(ErrorMessage = "El telefono del paciente es obligatoria")]
    public required string patientPhone { get; set; }

    public required int dentistId { get; set; }
    // public required int clinicalId { get; set; }

}