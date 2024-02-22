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
    public IActionResult getAllDentist(){
        var dentistas = _dentistService.getAllDentist();
        return Ok(dentistas);
    }

    [HttpPost]
    public IActionResult addDentist([FromBody] Dentist newDentist){
        _dentistService.addDentist(newDentist);
        return Ok("Dentist has been added succesfully");
    }

    
}
