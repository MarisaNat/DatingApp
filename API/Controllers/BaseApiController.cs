using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] //z.B. validiert automatisch die Werte, die an einen API-endpoint �bergeben werden. z.b darf username nicht leer sein
    [Route("api/[controller]")]

    public class BaseApiController : ControllerBase
    {

    }
}