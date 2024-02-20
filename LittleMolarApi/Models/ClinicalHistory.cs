namespace LittleMolarApi.Models;

public class ClinicalHistory{

    public required int id { get; set; }
    public required int patientId { get; set; }
    public required string patientIllness { get; set; }
}