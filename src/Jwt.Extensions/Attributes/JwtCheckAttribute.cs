using System;

namespace JWT.Extensions.Attributes
{
    /// <summary>
    /// Jwt check attribute
    /// it can be used on controller and method
    /// </summary>
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Method), AllowMultiple = false)]
    public class JwtCheckAttribute : Attribute
    {
        /// <summary>
        /// ignore jwt check
        /// </summary>
        public bool Ignore { get; set; } = false;
    }
}
