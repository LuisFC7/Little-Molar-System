using System.ComponentModel.DataAnnotations;

namespace LittleMolarApi.DTO;

public class LoginDto{

    [Required (ErrorMessage ="El usuario o correo es obligatorio")]
    public string identifier {get; set;}
    [Required (ErrorMessage ="La contraseña es obligatoria")]
    public string password {get;set;}
}