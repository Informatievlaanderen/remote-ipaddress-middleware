# Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware.AddRemoteIpAddress [![Build Status](https://github.com/Informatievlaanderen/remote-ipaddress-middleware/workflows/Build/badge.svg)](https://github.com/Informatievlaanderen/remote-ipaddress-middleware/actions)

Middleware component which adds a the remote IP id as a claim `urn:be:vlaanderen:vbr:ip` for the user on the request context.

The claim name is configurable as well.

## Usage

```csharp
public void Configure(IApplicationBuilder app, ...)
{
    app
        ...
        .UseMiddleware<AddRemoteIpAddressMiddleware>()
        ...
}
```

```csharp
public void Configure(IApplicationBuilder app, ...)
{
    app
        ...
        .UseMiddleware<AddRemoteIpAddressMiddleware>("urn:custom-claim:ip")
        ...
}
```
