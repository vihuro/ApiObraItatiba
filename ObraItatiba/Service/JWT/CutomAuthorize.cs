using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ObraItatiba.Service.JWT
{
    public class CutomAuthorize
    {
        public static bool ValidarClaimUsuario(HttpContext context, string claimName, string claimValue)
        {
            var permissions = claimValue.Split(',');
            if(!context.User.Identity.IsAuthenticated &&
               !context.User.Claims.Any(x => x.Type == claimName)) return false;
            var auth = permissions.Any(x => context.User.Claims.Any(c => c.Value == x));
            if (!auth) return false;
            return true;
        }
    }
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public RequisitoClaimFilter(Claim claims)
        {
            _claim = claims;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }
            
            if(!CutomAuthorize.ValidarClaimUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
