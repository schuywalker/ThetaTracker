namespace API.lib.dateManip;

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
        /*
        null firstDay == (0,:)
        null lastDay == (:, lastDay)
        firstDay gets first milli of that day
        lastDay get last milli of that day
        for single day, caller must enter same day for firstDay and lastDay


        
        Date instead of DateTime params??

        */
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
            startOfRange = firstDay.Value.Date;
            timeSpan = startOfRange.ToUniversalTime() - epoch;
            startingTS = (long)timeSpan.TotalSeconds;
        }

        if (lastDay is null)
        {
            endingTS = null;
        }
        else
        {
            endOfRange = lastDay.Value.Date.AddSeconds(86399); // One second less than a full day
            timeSpan = endOfRange.ToUniversalTime() - epoch;
            endingTS = (long)timeSpan.TotalSeconds;
        }

        return (startingTS, endingTS);
    }
}