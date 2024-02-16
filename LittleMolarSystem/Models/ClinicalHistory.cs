namespace LittleMolarSystem.Models;

public class ClinicalHistory{

    public required int id { get; set; }
    public required int patientId { get; set; }
    public required string patientName { get; set; }
    public required string clinicalIllness { get; set; }

}