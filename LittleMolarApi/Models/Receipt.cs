namespace LittleMolarApi.Models;

public class Receipt{

    public required int id { get; set; }
    public required int patientId { get; set; }
    public required int dentisId { get; set; }
    public required int receiptId { get; set; }
    public required string receiptTreatment { get; set; }
    public required string receiptDate { get; set; }

}