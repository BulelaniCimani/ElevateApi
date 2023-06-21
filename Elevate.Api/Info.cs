using Microsoft.OpenApi.Models;

namespace Elevate.Api
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}