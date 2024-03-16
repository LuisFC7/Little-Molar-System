
using System.ComponentModel.DataAnnotations;
namespace LittleMolarApi.DTO;

public class DentistDto{
   
    [Required(ErrorMessage = "El nombre del dentista es obligatorio.")]
    public string dentistName { get; set; }
    [Required(ErrorMessage = "El apellido del dentista es obligatorio.")]
    public string dentistLastName { get; set; }
    [Required(ErrorMessage ="El nombre del usuario es obligatorio.")]
    [StringLength(20, MinimumLength = 8,  ErrorMessage ="El nombre de usuario debe tener entre 8 y 20 caracteres")]
    public string dentistUser { get; set; }
    [Required(ErrorMessage ="La contraseña es obligatoria.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,20}$", ErrorMessage ="La contraseña debe contener al menos una mayuscula, un digito, un caracter especial y debe contener entre 8 a 20 caracteres")]

    public string dentistPassword { get; set; }

    [Required(ErrorMessage ="El email es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="El email no contiene el formato valido")]
    public string dentistEmail { get; set; }
    
    public int dentistAge { get; set; }
    [Required(ErrorMessage ="La cedula es obligatoria")]
    public int dentistId { get; set; }
    public string dentistPhone { get; set; }
}