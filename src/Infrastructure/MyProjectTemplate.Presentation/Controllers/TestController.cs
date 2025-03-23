using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyProjectTemplate.Presentation.Controllers;

public class TestController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {

        return Ok("Api Calisiyor.");
    }
}