namespace LittleMolarSystem.Models;

public class Patient{
    public required int id { get; set; }
    public required string patientName { get; set; }
    public required string patientLastName { get; set; }
    public required int patientAge { get; set; }
    public required int patientDentistId { get; set; }
    public required int patientClinicalId { get; set; }
}