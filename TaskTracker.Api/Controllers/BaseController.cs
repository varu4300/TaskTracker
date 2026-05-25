using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace TaskTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {

    }
}