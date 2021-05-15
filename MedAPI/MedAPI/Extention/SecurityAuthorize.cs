using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MedAPI.Extention
{
    public class SecurityAuthorize : AuthorizationFilterAttribute
    {

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                return Task.FromResult<object>(null);
            }

            var userName = principal.FindFirst(ClaimTypes.Name).Value;
            var userAllowedTime = principal.FindFirst("userAllowedTime").Value;

            //if (currentTime != userAllowedTime)
            //{
            //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed to access...bla bla");
            //    return Task.FromResult<object>(null);
            //}

            //User is Authorized, complete execution
            return Task.FromResult<object>(null);

        }
    }
}