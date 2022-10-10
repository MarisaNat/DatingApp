using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController] //z.B. validiert automatisch die Werte, die an einen API-endpoint übergeben werden. z.b darf username nicht leer sein
    [Route("api/[controller]")]

    public class BaseApiController : ControllerBase
    {

    }
}