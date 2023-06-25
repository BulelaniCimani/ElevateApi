using System;
namespace Elevate.Api.Application.ValueObjects
{
    public class AccessResponse
    {
        public string Token { get; set; }
        public bool IsAuthorezed { get; set; }
    }
}
