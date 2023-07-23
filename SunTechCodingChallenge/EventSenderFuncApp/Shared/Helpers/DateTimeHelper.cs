using System;


namespace EventSenderFuncApp.Shared.Helpers
{
    public static class DateTimeHelper
    {
        public static long ConvertDateTimetoEpoch(DateTime date)
        {
            try
            {
                var epochunixtime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return Convert.ToInt64((date - epochunixtime).TotalSeconds);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ConvertEpochUnixTimeToDateTime(long epochunixtime)
        {
            try
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return epoch.AddSeconds(epochunixtime);
            }
            catch
            {
                return new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
          
        }
    }
}
