namespace LittleMolarApi.Models;

public class Dentist{

    public int id { get; set; }
    public string dentistName { get; set; }
    public string dentistLastName { get; set; }
    public string dentistUser { get; set; }
    public string dentistPassword { get; set; }
    public string dentistEmail { get; set; }
    public int dentistAge { get; set; }
    public int dentistId { get; set; }
    public string dentistPhone { get; set; }

    public Dentist (
        int id,
        string dentistName,
        string dentistLastName,
        string dentistUser,
        string dentistPassword,
        string dentistEmail,
        int dentistAge,
        int dentistId,
        string dentistPhone)
    {
        this.id = id;
        this.dentistName = dentistName;
        this.dentistLastName = dentistLastName;
        this.dentistUser = dentistUser;
        this.dentistPassword = dentistPassword;
        this.dentistEmail = dentistEmail;
        this.dentistAge = dentistAge;
        this.dentistId = dentistId;
        this.dentistPhone = dentistPhone;
    }


}