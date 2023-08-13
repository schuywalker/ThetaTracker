using API.lib;
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

    public OptionContract GetOptionContracts(string ticker, decimal strike, DateTime start, DateTime end, OptionType cp)
    {
        throw new NotImplementedException();
    }


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

    OptionContract IOptionContractsRepository.GetOptionContracts(string ticker, double strike, long createdTS)
    {
        throw new NotImplementedException();
    }
    List<OptionContract> IOptionContractsRepository.GetOptionContracts(string ticker, double strike, long contractDateStart, long contractDateEnd, OptionType cp, long? expirationDateStart, long? expirationDateEnd)
    {
        try
        {
            FilterDefinition<OptionContract> dateFilter = Builders<OptionContract>.Filter.Gte(x => x.createdTS, contractDateStart) &
            Builders<OptionContract>.Filter.Lte(x => x.createdTS, contractDateEnd);
            FilterDefinition<OptionContract> strikeFilter = Builders<OptionContract>.Filter.Where(x => x.strike == strike);
            FilterDefinition<OptionContract> cpFilter = Builders<OptionContract>.Filter.Where(x => x.cp == OptionTypeHelper.OptionTypeToString(cp));


            FilterDefinition<OptionContract> combinedFilter = dateFilter & strikeFilter & cpFilter;

            if (expirationDateStart != null && expirationDateEnd != null)
            {
                FilterDefinition<OptionContract> expirationDateFilter = Builders<OptionContract>.Filter.Gte(x => x.expirationDateTS, expirationDateStart) &
                Builders<OptionContract>.Filter.Lte(x => x.expirationDateTS, expirationDateEnd);
                combinedFilter = combinedFilter & expirationDateFilter;
            }


            var results = _collection.Find(combinedFilter).ToList();
            return results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        throw new InvalidOperationException();
    }
}