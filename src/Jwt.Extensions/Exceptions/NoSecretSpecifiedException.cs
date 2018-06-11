using System;

namespace JWT.Extensions.Exceptions
{
    /// <summary>
    /// no secret specified
    /// </summary>
    public class NoSecretSpecifiedException : Exception
    {
        public NoSecretSpecifiedException(string message = "No secret specified") : base(message)
        { }
    }
}
