using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiCotroller : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator =>
                _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>() 
                ?? throw new InvalidOperationException("IMediator service not found");
    }
}
