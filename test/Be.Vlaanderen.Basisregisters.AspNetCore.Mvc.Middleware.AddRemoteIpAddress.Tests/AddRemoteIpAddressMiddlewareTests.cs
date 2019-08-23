namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware.AddRemoteIpAddress.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class AddRemoteIpAddressMiddlewareTests
    {
        [Fact]
        public async Task AddsExpectedIPToUserClaims()
        {
            var middleware = new AddRemoteIpAddressMiddleware(innerContext => Task.CompletedTask);
            var context = new DefaultHttpContext();
            var ipString = "123.245.123.245";
            context.Connection.RemoteIpAddress = IPAddress.Parse(ipString);

            await middleware.Invoke(context);

            context.User.HasClaim(AddRemoteIpAddressMiddleware.UrnBasisregistersVlaanderenIp, ipString).Should().BeTrue();
        }
    }
}
