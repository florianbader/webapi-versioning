using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiVersioning.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiVersionNeutral]
    public class ApisController : ControllerBase
    {
        [HttpOptions]
        public IActionResult GetApis()
        {
            var controllers = typeof(ApisController).Assembly
                .GetTypes()
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && !t.IsAbstract);

            var apiVersions = new Dictionary<string, ApiVersion>();
            foreach (var controller in controllers)
            {
                var route = (controller.GetCustomAttributes(typeof(RouteAttribute), false)
                    .FirstOrDefault() as RouteAttribute)?.Template ?? "";

                var versions = controller.GetCustomAttributes(typeof(ApiVersionAttribute), false)
                    .Cast<ApiVersionAttribute>()
                    .SelectMany(v => v.Versions)
                    .Select(v => new Version(v.MajorVersion.Value, v.MinorVersion.Value))
                    .ToArray();

                if (versions.Length == 0) continue;

                var minVersion = versions.Min();
                var maxVersion = versions.Max();

                if (apiVersions.ContainsKey(route))
                {
                    apiVersions[route].MinVersion = apiVersions[route].MinVersion > minVersion ? minVersion : apiVersions[route].MinVersion;
                    apiVersions[route].MaxVersion = apiVersions[route].MaxVersion < maxVersion ? maxVersion : apiVersions[route].MaxVersion;
                }
                else
                {
                    apiVersions.Add(route, new ApiVersion { Route = route, MinVersion = minVersion, MaxVersion = maxVersion });
                }
            }

            return Ok(apiVersions.Values);
        }
    }
}