add  Authorize Attribute


```cs
[Authorize]
public class UserController : Controller
```    

未配置验证信息

client

```
401 Unauthorized
```



```
Application Insights Telemetry (unconfigured): {"name":"Microsoft.ApplicationInsights.Dev.Message","time":"2017-05-07T11:11:45.1720
Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request starting HTTP/1.1 GET http://localhost:50707/api/user/getusers  


Application Insights Telemetry (unconfigured): {"name":"Microsoft.ApplicationInsights.Dev.Message","time":"2017-05-07T11:11:45.1780346Z","tags":{"ai.internal.nodeName":"DESKTOP-DHCJOJ9","ai.cloud.roleInstance":"DESKTOP-DHCJOJ9","ai.application.ver":"1.0.0.0","ai.operation.id":"0HL4L76O6U2OD","ai.internal.sdkVersion":"aspnet5c:2.0.0","ai.operation.name":"GET /api/user/getusers","ai.location.ip":"::1"},"data":{"baseType":"MessageData","baseData":{"ver":2,"message":"AuthenticationScheme: idsrv was not authenticated.","severityLevel":"Verbose","properties":{"CategoryName":"Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware","AspNetCoreEnvironment":"Development","{OriginalFormat}":"AuthenticationScheme: {AuthenticationScheme} was not authenticated.","DeveloperMode":"true","AuthenticationScheme":"idsrv"}}}}
```

