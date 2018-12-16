namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Add the remote ip address as a claim (urn:basisregisters:vlaanderen:ip).
    /// </summary>
    public class AddRemoteIpAddressMiddleware
    {
        public const string UrnBasisregistersVlaanderenIp = "urn:basisregisters:vlaanderen:ip";

        private readonly RequestDelegate _next;

        public AddRemoteIpAddressMiddleware(RequestDelegate next) => _next = next;

        public Task Invoke(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress;

            if (ip != null && context.User.Identity is ClaimsIdentity user && !user.HasClaim(x => x.Type == UrnBasisregistersVlaanderenIp))
                user.AddClaim(new Claim(UrnBasisregistersVlaanderenIp, ip.ToString(), ClaimValueTypes.String));

            return _next(context);
        }
    }
}
