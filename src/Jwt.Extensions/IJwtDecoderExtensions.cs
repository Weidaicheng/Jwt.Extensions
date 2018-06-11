using System.Collections.Generic;

namespace JWT.Extensions
{
    /// <summary>
    /// Extensions for IJwtDecoder
    /// </summary>
    public static class IJwtDecoderExtensions
    {
        /// <summary>
        /// use <see cref="IJwtDecoder.Decode(string, string, bool)"/> and verify is always on
        /// </summary>
        /// <param name="jwtDecoder"></param>
        /// <param name="token">The JWT.</param>
        /// <param name="key">The key that was used to sign the JWT.</param>
        /// <param name="result">A string containing the JSON payload.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryDecode(this IJwtDecoder jwtDecoder, string token, string key, out string result)
        {
            try
            {
                result = jwtDecoder.Decode(token, key, true);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// use <see cref="IJwtDecoder.Decode(string, byte[], bool)"/> and verify is always on
        /// </summary>
        /// <param name="jwtDecoder"></param>
        /// <param name="token">The JWT.</param>
        /// <param name="key">The key that was used to sign the JWT.</param>
        /// <param name="result">A string containing the JSON payload.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryDecode(this IJwtDecoder jwtDecoder, string token, byte[] key, out string result)
        {
            try
            {
                result = jwtDecoder.Decode(token, key, true);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// use <see cref="IJwtDecoder.DecodeToObject(string, string, bool)"/> and verify is always on
        /// </summary>
        /// <param name="jwtDecoder"></param>
        /// <param name="token">The JWT.</param>
        /// <param name="key">The key that was used to sign the JWT.</param>
        /// <param name="result">An object representing the payload.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryDecodeToObject(this IJwtDecoder jwtDecoder, string token, string key, out IDictionary<string, object> result)
        {
            try
            {
                result = jwtDecoder.DecodeToObject(token, key, true);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// use <see cref="IJwtDecoder.DecodeToObject(string, byte[], bool)"/> and verify is always on
        /// </summary>
        /// <param name="jwtDecoder"></param>
        /// <param name="token">The JWT.</param>
        /// <param name="key">The key that was used to sign the JWT.</param>
        /// <param name="result">An object representing the payload.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryDecodeToObject(this IJwtDecoder jwtDecoder, string token, byte[] key, out IDictionary<string, object> result)
        {
            try
            {
                result = jwtDecoder.DecodeToObject(token, key, true);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// use <see cref="IJwtDecoder.DecodeToObject{T}(string, string, bool)"/> and verify is always on
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jwtDecoder"></param>
        /// <param name="token">The JWT.</param>
        /// <param name="key">The key that was used to sign the JWT.</param>
        /// <param name="result">An object representing the payload.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryDecodeToObject<T>(this IJwtDecoder jwtDecoder, string token, string key, out T result)
        {
            try
            {
                result = jwtDecoder.DecodeToObject<T>(token, key, true);
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }

        /// <summary>
        /// use <see cref="IJwtDecoder.DecodeToObject{T}(string, byte[], bool)"/> and verify is always on
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jwtDecoder"></param>
        /// <param name="token">The JWT.</param>
        /// <param name="key">The key that was used to sign the JWT.</param>
        /// <param name="result">An object representing the payload.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryDecodeToObject<T>(this IJwtDecoder jwtDecoder, string token, byte[] key, out T result)
        {
            try
            {
                result = jwtDecoder.DecodeToObject<T>(token, key, true);
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
    }
}
