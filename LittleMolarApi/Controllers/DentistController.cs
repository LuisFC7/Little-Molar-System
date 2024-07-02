using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;
using LittleMolarApi.DTO;
using LittleMolarApi.DTO.ResponsesDTO;
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
    private readonly JwtService _jwtService;



    public DentistController(IDentist dentistService, ISessionImp sessionImp, JwtService jwtService){
        _dentistService = dentistService;
        _sessionImp = sessionImp;
        _jwtService = jwtService;
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
    // [ProducesResponseType(200)]
    // [ProducesResponseType(400)]
    // [ProducesResponseType(500)]

    [HttpPost]
    [Route("dentistLogin")]
    [ProducesResponseType(typeof(LoginResponseDTO), 200)]
    [ProducesResponseType(typeof(ErrorResponseDTO), 400)]
    [ProducesResponseType(typeof(ErrorResponseDTO), 500)]
    public async Task<IActionResult> dentistLogin([FromBody] LoginDto loginDto){
        try{
            if(loginDto == null)
                return BadRequest(new ErrorResponseDTO{Message = "The message cannot be empty or null"});

                // return  StatusCode(400, "The messague cannot be empty or null");

            var token = await _dentistService.loginDentist(loginDto);

            if(token == null)
                return BadRequest(new ErrorResponseDTO{Message = "Usuario o password incorrecto"});

            return Ok(new LoginResponseDTO{ message = "Login Success", token = token});
            // return Ok(new { token });

        }catch (Exception ex){
            return StatusCode(500, new ErrorResponseDTO{
                Error = "An unexpected error has been ocurred: " + ex.Message
            });

            // return StatusCode(500, new { error = "An unexpected error has occurred: " + ex.Message });
        }
    }

    [HttpPost]
    [Route("dentistSideBar")]
    [ProducesResponseType(typeof(LoginResponseDTO), 200)]
    [ProducesResponseType(typeof(ErrorResponseDTO), 400)]
    [ProducesResponseType(typeof(ErrorResponseDTO), 500)]
    public async Task<IActionResult> dentistSideBar([FromBody] string token){
        try{
            if(token == null)
                return BadRequest(new ErrorResponseDTO{Message = "No se ha proporcionado el token."});

            //DecodificarR el token
            var numberId = _jwtService.DecodeJwt(token);
            var dentistData = await _dentistService.getSideBarDentist(numberId);

            if (dentistData == null)
                return NotFound(new ErrorResponseDTO { Message = "Dentista no encontrado." });
            Console.WriteLine("POSIBLE FALLA");
            Console.WriteLine(dentistData);
            return Ok(dentistData);
            
        }catch (Exception ex){
            return StatusCode(500, new ErrorResponseDTO{
                Error = "An unexpected error has been ocurred: " + ex.Message
            });

            // return StatusCode(500, new { error = "An unexpected error has occurred: " + ex.Message });
        }
    }
 

    // [HttpDelete]
    // [Route("deleteDentist")]
    // public IActionResult deleteDentist([FromQuery] int dentistId){
    //     _dentistService.deleteDentist(dentistId);
    //     return Ok("Dentist has been deleted successfully");
    // }

}
