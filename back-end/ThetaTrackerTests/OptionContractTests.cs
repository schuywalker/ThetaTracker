
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
    }

    [TestMethod]
    public void GetOptionContract_ReturnsExpectedResult()
    {
        // obviously not a great idea to test hard data - just using to get things running
        var collection = new OptionContractRepository(database, "PLTR");

        // Arrange
        var expectedLastTradeDate = 1690573899;
        var service = new OptionContractsService(collection);

        // Act
        OptionContract result = service.GetOptionContracts("PLTR", "PLTR230804C00015000", 1690778143);

        // Assert
        Assert.AreEqual(expectedLastTradeDate, result.lastTradeDate);
    }













    [ClassCleanup]
    public static void Cleanup()
    {
        // intentionally blank for now
    }


}