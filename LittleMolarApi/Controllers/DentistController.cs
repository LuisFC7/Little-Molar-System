using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;

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
    public IActionResult getAllDentist(){

        try{

            var dentistas = _dentistService.getAllDentist();
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
    public IActionResult addDentist([FromBody] Dentist newDentist){

        try{

            if(newDentist == null){
                return  StatusCode(400, "The messague cannot be empty or null");
            }

            _dentistService.addDentist(newDentist);
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
    public IActionResult updateDentist([FromBody] Dentist newDentist){

        if(newDentist != null){
            _dentistService.updateDentist(newDentist);
            return Ok("Data has been update succesfully");
        }else{
            throw new InvalidOperationException($"Is missing some data in updating dentist.");
        }
    }

    [HttpDelete]
    [Route("deleteDentist")]
    public IActionResult deleteDentist([FromQuery] int dentistId){
        _dentistService.deleteDentist(dentistId);
        return Ok("Dentist has been deleted successfully");
    }


    
}
