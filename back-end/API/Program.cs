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




        DateTime date = DateTime.ParseExact("2023-09-12", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime expirationDate = DateTime.ParseExact("2023-09-29", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        // List<OptionContract> documents = service.GetOptionContracts(35, date, date.AddDays(5), lib.OptionType.CALL, null, date.AddDays(15));
        List<OptionContract> documents = service.GetOptionContracts(30, date, date, lib.OptionType.CALL, null, null);
        Console.WriteLine(documents.Count);
        foreach (var doc in documents)
        {
            Console.WriteLine($"bid: {doc.bid} ask: {doc.ask} expiration: {DateManip.TimestampToDateTime(doc.expirationDateTS)}");
        }
        List<OptionContract> putsExample = service.GetOptionContracts(30, date, date, lib.OptionType.PUT, null, null);
        Console.WriteLine(putsExample.Count);
        foreach (var put in putsExample)
        {
            Console.WriteLine($"bid: {put.bid} ask: {put.ask} expiration: {DateManip.TimestampToDateTime(put.expirationDateTS)}");
        }
        Console.WriteLine($"\n{putsExample[0]}");


    }
}