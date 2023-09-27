namespace API.Utils;

using System.Globalization;

public class DateManip
{
    public static DateTime TimestampToDateTime(long timestamp)
    {
        DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddSeconds(timestamp);
    }
    public static (long? startQueryTS, long? endQueryTS) GetDayRange(DateTime? firstDay, DateTime? lastDay)
    {
        DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        long? startingTS;
        long? endingTS;
        TimeSpan timeSpan;
        DateTime startOfRange;
        DateTime endOfRange;

        if (firstDay is null)
        {
            startingTS = null;
        }
        else
        {
            startOfRange = firstDay.Value.Date; // Value works on nullable DateTime
            timeSpan = startOfRange.ToUniversalTime() - epoch;
            startingTS = (long)timeSpan.TotalSeconds;
        }

        if (lastDay is null)
        {
            endingTS = null;
        }
        else
        {
            endOfRange = lastDay.Value.Date.AddSeconds(86399); // full day - 1 second
            timeSpan = endOfRange.ToUniversalTime() - epoch;
            endingTS = (long)timeSpan.TotalSeconds;
        }

        return (startingTS, endingTS);
    }
}