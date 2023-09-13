
using System.Globalization;
using API.lib.dateManip;

namespace ThetaTrackerTests;

[TestClass]
public class LibTests
{
    // private readonly DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


    [TestMethod]
    public void GetDayRange_ReturnsExpected_SameDay()
    {
        // Arrange
        DateTime? firstDay = DateTime.ParseExact("2023-09-13", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime? lastDay = firstDay.Value.AddSeconds(86399);
        (long? startQueryTS, long? endQueryTS) expected = (1631500800, 1631587199);

        // Act
        (long? startQueryTS, long? endQueryTS) result = DateManip.GetDayRange(firstDay, lastDay);

        // Assert
        Assert.AreEqual(expected, result);
    }
    [TestMethod]
    public void GetDayRange_ReturnsExpected_DifferentDays()
    {
        // Arrange
        DateTime? firstDay = DateTime.ParseExact("2023-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime? lastDay = DateTime.ParseExact("2023-09-13", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        (long? startQueryTS, long? endQueryTS) expected = (1630454400, 1631587199);

        // Act
        (long? startQueryTS, long? endQueryTS) result = DateManip.GetDayRange(firstDay, lastDay);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void GetDayRange_ReturnsExpected_StartDateNull()
    {
        // Arrange
        DateTime? firstDay = null;
        DateTime? lastDay = DateTime.ParseExact("2023-09-13", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        (long? startQueryTS, long? endQueryTS) expected = (null, 1631587199);
        // Act
        (long? startQueryTS, long? endQueryTS) result = DateManip.GetDayRange(firstDay, lastDay);
        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void GetDayRange_ReturnsExpected_EndDateNull()
    {
        // Arrange
        DateTime? firstDay = DateTime.ParseExact("2023-09-13", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime? lastDay = null;
        (long? startQueryTS, long? endQueryTS) expected = (1631500800, null);
        // Act
        (long? startQueryTS, long? endQueryTS) result = DateManip.GetDayRange(firstDay, lastDay);
        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void GetDayRange_ReturnsExpected_BothNull()
    {
        // Arrange
        DateTime? firstDay = null;
        DateTime? lastDay = null;
        (long? startQueryTS, long? endQueryTS) expected = (null, null);
        // Act
        (long? startQueryTS, long? endQueryTS) result = DateManip.GetDayRange(firstDay, lastDay);
        // Assert
        Assert.AreEqual(expected, result);
    }
}