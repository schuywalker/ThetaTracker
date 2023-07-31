using System;
using MongoDB.Driver;
using MongoDB.Bson;
using API.Repositories;
using API.Services;


namespace API;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = "mongodb://localhost:27017";
        var mongoClient = new MongoClient(connectionString);
        var database = mongoClient.GetDatabase("option_chains");
        // var collection = mongoClient.GetDatabase("option_chains").GetCollection<BsonDocument>("AAPL");

        var repo = new OptionContractRepository(database, "PLTR");
        var service = new OptionContractsService(repo);

        var document = service.GetOptionContracts("PLTR", "PLTR230804C00015000", 1690778143);
        Console.WriteLine(document);

        Console.WriteLine("test");

        // // var filter = Builders<BsonDocument>.Filter.Eq("contractSymbol", "AAPL230721C00055000");
        // var filter = Builders<BsonDocument>.Filter.Eq("contractSymbol", "AAPL230721C00055000");
        // // var filter = Builders<BsonDocument>.Filter.Gt("openInterest", 10000);
        // // var document = collection.Find(filter).First();
        // var document = collection.Find(filter).ToList();
        // // Console.WriteLine(document);
        // foreach (var doc in document)
        // {
        //     Console.WriteLine(doc["lastPrice"]);
        // }

    }
}




// // var filter = Builders<BsonDocument>.Filter.Eq("contractSymbol", "AAPL230721C00055000");
// var filter = Builders<BsonDocument>.Filter.Eq("contractSymbol", "AAPL230721C00055000");
// // var filter = Builders<BsonDocument>.Filter.Gt("openInterest", 10000);
// // var document = collection.Find(filter).First();
// var document = collection.Find(filter).ToList();
// // Console.WriteLine(document);
// foreach (var doc in document)
// {
//     Console.WriteLine(doc["lastPrice"]);
// }

