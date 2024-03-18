using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleMolarApi.Models;

public class Patient{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string patientName { get; set; }
    public string patientLastName { get; set; }
    public int patientAge { get; set; }
    public string patientPhone { get; set; }
    public int dentistId { get; set; }
    // public required int clinicalId { get; set; }

    public Patient(
        string patientName,
        string patientLastName,
        int patientAge,
        string patientPhone,
        int dentistId)
    {
        this.patientName = patientName;
        this.patientLastName = patientLastName;
        this.patientAge = patientAge;
        this.patientPhone = patientPhone;
        this.dentistId = dentistId;
    }


    

}