using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;
using LittleMolarApi.DTO;

namespace LittleMolarApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentistController : ControllerBase{

    private readonly IDentist _dentistService;
    public DentistController(IDentist dentistService){
        _dentistService = dentistService;
    }

    [HttpGet]
    [Route("getAlLDentist")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> getAllDentist(){

        try{
            var dentistas = await _dentistService.getAllDentist();
            return Ok(dentistas);

        }catch (Exception ex){
            return StatusCode(500, "An error has been occurred: " + ex);
        }

    }

    [HttpPost]
    [Route("addDentist")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> addDentist([FromBody] DentistDto newDentist){

        try{
            if(newDentist == null){
                return  StatusCode(400, "The messague cannot be empty or null");
            }

            if(_dentistService.usernameDentistExist(newDentist.dentistUser) || _dentistService .emailDentistExist(newDentist.dentistEmail)){
                return BadRequest("El nombre de usuario o el correo electrónico ya están en uso.");
            }

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
    public async Task<IActionResult> updateDentist([FromBody] DentistDto updateDentist, int id){
        try{
            if(updateDentist == null)
                return  StatusCode(400, "The messague cannot be empty or null");

            // if(_dentistService.usernameDentistExist(updateDentist.dentistUser) || _dentistService .emailDentistExist(updateDentist.dentistEmail))
            //         return BadRequest("El nombre de usuario o el correo electrónico ya están en uso.");
            
            await _dentistService.updateDentist(updateDentist, id);
            return Ok("Data has been update succesfully");

        }catch (Exception ex){
            return StatusCode(500, "An unexpected error has been ocurred: " + ex);
        }

    }

    

    // [HttpDelete]
    // [Route("deleteDentist")]
    // public IActionResult deleteDentist([FromQuery] int dentistId){
    //     _dentistService.deleteDentist(dentistId);
    //     return Ok("Dentist has been deleted successfully");
    // }


    
}
