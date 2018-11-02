using Lacey.Medusa.Common.Web.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Lacey.Medusa.Common.Web.Controllers.Common
{
    [Route(Routes.ApiRoute + "[controller]")]
    public abstract class ApiController : Controller
    {        
    }
}