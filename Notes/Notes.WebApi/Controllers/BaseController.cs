using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.WebApi.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator()
    {
        return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }

    internal Guid UserId()
    {
        return !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}