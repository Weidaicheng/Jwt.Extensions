using System;

namespace JWT.Extensions.Utility
{
    public class UtilityHelper
    {
        /// <summary>
		/// Get timestamp
		/// </summary>
		/// <returns></returns>
		public static long GetTimeStamp()
        {
            DateTime startUtc = new DateTime(1970, 1, 1);
            DateTime nowUtc = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc);
            return (long)(nowUtc - startUtc).TotalSeconds;
        }
    }
}
