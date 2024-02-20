namespace LittleMolarApi.Models;

public class Patient{

    public required int id { get; set; }
    public required string patientName { get; set; }
    public required string patientLastName { get; set; }
    public required int patientAge { get; set; }
    public required string patientPhone { get; set; }
    public required int dentistId { get; set; }
    public required int clinicalId { get; set; }

}