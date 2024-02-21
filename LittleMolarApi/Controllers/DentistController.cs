using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Services;

namespace LittleMolarApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentistController : ControllerBase{

    private readonly  DentistService _dentistService;

    public DentistController(DentistService dentistService){
        _dentistService = dentistService;
    }

    [HttpGet]
    public IActionResult getAllDentist(){
        var dentistas = _dentistService.getAllDentist();
        return Ok(dentistas);
    }

}
