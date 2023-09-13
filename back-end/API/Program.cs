using System;
using MongoDB.Driver;
using MongoDB.Bson;
using API.Repositories;
using API.Services;
using System.Globalization;
using API.lib.dateManip;
using API.Models;

namespace API;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = "mongodb://localhost:27017";

        var mongoClient = new MongoClient(connectionString);
        var database = mongoClient.GetDatabase("option_chains");

        string ticker = "AI";

        var repo = new OptionContractRepository(database, ticker);
        var service = new OptionContractsService(repo);




        DateTime date = DateTime.ParseExact("2023-08-11", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime expirationDate = DateTime.ParseExact("2023-08-18", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        List<OptionContract> documents = service.GetOptionContracts(35, date, date.AddDays(5), lib.OptionType.CALL, null, date.AddDays(15));
        Console.WriteLine(documents.Count);
        foreach (var doc in documents)
        {
            Console.WriteLine($"bid: {doc.bid} ask: {doc.ask} expiration: {DateManip.TimestampToDateTime(doc.expirationDateTS)}");
        }


    }
}