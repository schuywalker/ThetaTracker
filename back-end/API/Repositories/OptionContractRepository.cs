using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Repositories;

public class OptionContractRepository : IOptionContractsRepository
{
    private readonly IMongoCollection<OptionContract> _collection;

    public OptionContractRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<OptionContract>(collectionName);
    }

    // OptionContract IOptionContractsRepository.GetOptionContracts(string ticker, string contractSymbol)
    // {
    //     throw new NotImplementedException();
    // }


    OptionContract? IOptionContractsRepository.GetOptionContracts(string ticker, string contractSymbol, long createdTS)
    {
        try
        {
            FilterDefinition<OptionContract> filter = Builders<OptionContract>.Filter.Where(x => x.contractSymbol == contractSymbol &&
            x.createdTS == createdTS);
            var count = _collection.Find(filter).CountDocuments();
            Console.WriteLine(count);
            OptionContract document = _collection.Find(filter).FirstOrDefault();

            return document;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    // OptionContract IOptionContractRepository.GetOptionContracts(string ticker, decimal strike)
    // {
    //     throw new NotImplementedException();
    // }


    OptionContract IOptionContractsRepository.GetOptionContracts(string ticker, decimal strike, long createdTS)
    {
        throw new NotImplementedException();
    }
}