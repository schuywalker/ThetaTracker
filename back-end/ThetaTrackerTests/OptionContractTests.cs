
using System.Globalization;
using Amazon.Runtime.Internal;
using MongoDB.Driver;
using Moq;


namespace ThetaTrackerTests;

[TestClass]
public class OptionContractTests
{

    private static MongoClient _dbConnection = new MongoClient("mongodb://localhost:27017");
    private static IMongoDatabase database = _dbConnection.GetDatabase("option_chains");

    [ClassInitialize]
    public static void Setup(TestContext context)
    {
        // leaving connections outside for now because I don't need them to run before every test
        string ticker = "TSLA";
        var repo = new OptionContractRepository(database, ticker);
        var service = new OptionContractsService(repo);
    }

    // [TestMethod]
    // public void GetOptionContract_ReturnsExpectedResult()
    // {
    //     // obviously not a great idea to test hard data - just using to get things running
    //     var collection = new OptionContractRepository(database, "PLTR");

    //     // Arrange
    //     var expectedLastTradeDate = 1690573899;
    //     var service = new OptionContractsService(collection);

    //     // Act
    //     OptionContract result = service.GetOptionContracts("PLTR", "PLTR230804C00015000", 1690778143);

    //     // Assert
    //     Assert.AreEqual(expectedLastTradeDate, result.lastTradeDate);
    // }



    [TestMethod]
    public void BuildDateFields()
    {

        DateTime date = DateTime.ParseExact("2023-09-13", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime expirationDate = DateTime.ParseExact("2023-09-13", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        // List<OptionContract> documents = ServiceClientHelpers.GetOptionContracts(270, date, date.AddDays(5), lib.OptionType.CALL, null, date.AddDays(15));
    }












    [ClassCleanup]
    public static void Cleanup()
    {
        // intentionally blank for now
    }


}