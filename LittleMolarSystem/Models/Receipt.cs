namespace LittleMolarSystem.Models;

public class Receipt{

    public required int id { get; set; }
    public required int patientId { get; set; }
    public required int dentistId { get; set; }
    public required string receiptDiag { get; set; }
    public required string receiptTreatment { get; set; }
    public required string receiptDate { get; set; }


}