using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;
using LittleMolarApi.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using LittleMolarApi.Services;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;

namespace LittleMolarApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentistController : ControllerBase{

    private readonly IDentist _dentistService;
    private readonly ISessionImp _sessionImp;



    public DentistController(IDentist dentistService, ISessionImp sessionImp){
        _dentistService = dentistService;
        _sessionImp = sessionImp;
    }

    [HttpPost]
    [Route("addDentist")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> addDentist([FromBody] DentistDto newDentist){

        try{
            if(newDentist == null)
                return  StatusCode(400, "The messague cannot be empty or null");

            if(_dentistService.validateExistence("Dentist", "dentistUser", newDentist.dentistUser))
                return BadRequest("El nombre de usuario ya se encuentra en uso.");

            if(_dentistService.validateExistence("Dentist", "dentistEmail", newDentist.dentistEmail))
                return BadRequest("El email ingresado ya ha sido registrado.");

            await _dentistService.addDentist(newDentist);
            return Ok("Dentist has been added succesfully " + newDentist);

        }catch (Exception ex){
            return StatusCode(500, "An unexpected error has been ocurred: " + ex);
        }
    }

    [HttpPost]
    [Route("updateDentist")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> updateDentist([FromBody] DentistUpDto updateDentist){
        try{
            if(updateDentist == null)
                return  StatusCode(400, "The messague cannot be empty or null");
            
            await _dentistService.updateDentist(updateDentist);
            return Ok("Data has been update succesfully");

        }catch (Exception ex){
            return StatusCode(500, "An unexpected error has been ocurred: " + ex);
        }

    }

    [HttpPost]
    [Route("createPatient")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> createPatient([FromBody] PatientDTO newPatient){
        try{
            if(newPatient == null)
                return  StatusCode(400, "The messague cannot be empty or null");

            await _dentistService.createPatient(newPatient);
            return Ok("El paciente ha sido creado correctamente " + newPatient);

        }catch (Exception ex){
            return StatusCode(500, "An unexpected error has been ocurred: " + ex);
        }
    }

    [HttpGet]
    [Route("getAllPatients")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> getAllPatients(){
        try{
            var patients = await _dentistService.getAllPatients();
            return Ok(patients);

        }catch (Exception ex){
            return StatusCode(500, "An error has been occurred: " + ex);
        }

    }

    [HttpPost]
    [Route("dentistLogin")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> dentistLogin([FromBody] LoginDto loginDto){
        try{
            if(loginDto == null)
                return  StatusCode(400, "The messague cannot be empty or null");

            var result = await _sessionImp.authenticateAsync(loginDto.identifier, loginDto.password);

            if(result == "El usuario o email es erroneo")
                return BadRequest("El usuario o email es erroneo");

            if(result == "La contraseña es erronea")
                return BadRequest("La contraseña es erronea");

            if(result == null)
                return BadRequest("Algo salio mal");

            string[] content = result.Split('/');
            string id="";
            string token="";
            if(content.Length >= 2){
                id = content[0];
                token = content[1];
            }else{
                return BadRequest("Algo salio mal");
            }
            Console.WriteLine("Data LogIn: "+ id +" / "+ token);
            var response = new { Id = id, Token = token };
        
            return Ok(response);
            // return Ok("Inicio de sesión exitoso " + loginDto);

        }catch (Exception ex){
            return StatusCode(500, "An unexpected error has been ocurred: " + ex);
        }
    }


    // [HttpPost("LogOut")]
    // [Authorize]
    // public IActionResult Logout(){
    //     var jwt = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
    //     Console.WriteLine("JWT: "+jwt);
        
    //     if (!string.IsNullOrEmpty(jwt))
    //     {
    //         Console.WriteLine("JWT: "+jwt);
    //         _sessionImp.logOut(jwt);
    //         // Aquí podrías agregar alguna lógica adicional, como redireccionar al usuario a la página de login si lo deseas
    //         return Ok("Logout exitoso.");
    //     }

    //     return BadRequest("No se proporcionó un token JWT en el encabezado de autorización.");
    // }
    [HttpPost]
    [Route("dentistLogOut")]
    [Authorize]
    public async Task<IActionResult> Logout([FromBody] string token)
    {
        var jwt = HttpContext.User?.FindFirstValue("jwt");

        if (!string.IsNullOrEmpty(jwt))
        {
            _sessionImp.logOut(jwt);
            // return RedirectToAction("Login");
        }

        return BadRequest("No se pudo encontrar el token JWT del usuario.");
    }

    
    // [HttpPost]
    // [Route("dentistLogOut")]
    // [ProducesResponseType(200)]
    // [ProducesResponseType(400)]
    // [ProducesResponseType(500)]
    // [Authorize]
    // public IActionResult Logout(string token){
    //     try
    //     {
    //         _sessionImp.logOut(token);
    //         return Ok(new { Message = "Sesión cerrada exitosamente." });
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, new { Message = "Se produjo un error al cerrar sesión.", Error = ex.Message });
    //     }
    // }

    // [HttpDelete]
    // [Route("deleteDentist")]
    // public IActionResult deleteDentist([FromQuery] int dentistId){
    //     _dentistService.deleteDentist(dentistId);
    //     return Ok("Dentist has been deleted successfully");
    // }




}
