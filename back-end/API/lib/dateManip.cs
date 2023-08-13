namespace API.lib.dateManip;

using System.Globalization;

public class dateManip
{
    public static DateTime TimestampToDateTime(long timestamp)
    {
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddSeconds(timestamp);
    }
    public static (long StartOfDay, long EndOfDay) GetDayRange(DateTime date)
    {
        DateTime startOfDate = date.Date;
        DateTime endOfDate = startOfDate.AddSeconds(86399); // One second less than a full day

        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        TimeSpan timeSpan = startOfDate.ToUniversalTime() - epoch;
        long startingTS = (long)timeSpan.TotalSeconds;

        timeSpan = endOfDate.ToUniversalTime() - epoch;
        long endingTS = (long)timeSpan.TotalSeconds;

        return (startingTS, endingTS);
    }
}