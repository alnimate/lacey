using Microsoft.AspNetCore.Authorization;

namespace Lacey.Medusa.Common.Web.Controllers.Common
{
    [Authorize]
    public abstract class AuthorizeApiController : ApiController
    {        
    }
}