using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyProjectTemplate.Presentation.Controllers;

public class TestController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public IActionResult GetAsync()
    {
        return Ok("qwe");
    }
}