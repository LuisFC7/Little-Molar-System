
using System.ComponentModel.DataAnnotations;
namespace LittleMolarApi.DTO;

public class DentistSideBarDTO{
    
    public int id { get; set; }
    public string dentistUser { get; set; }
    public string dentistName { get; set; }
    public string dentistLastName { get; set; }
    public string dentistImage { get; set; }
}