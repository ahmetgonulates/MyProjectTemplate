using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyProjectTemplate.Presentation;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
}