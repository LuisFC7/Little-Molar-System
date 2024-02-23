using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Services;
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
    [ProducesResponseType(500)]
    public IActionResult addDentist([FromBody] Dentist newDentist){

        try{

            if(newDentist == null){
                return BadRequest("The messague cannot be empty or null");
            }

            _dentistService.addDentist(newDentist);
            return Ok("Dentist has been added succesfully " + newDentist);

        }catch (Exception ex){
            return StatusCode(500, "An unexpected error has been ocurred: " + ex);
        }
    }

    
}
