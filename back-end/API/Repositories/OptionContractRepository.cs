using API.lib;
using API.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace API.Repositories;

public class OptionContractRepository : IOptionContractsRepository
{
    private readonly IMongoCollection<OptionContract> _collection;

    public OptionContractRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<OptionContract>(collectionName);
    }

    public OptionContract GetOptionContracts(decimal strike, DateTime start, DateTime end, OptionType cp)
    {
        throw new NotImplementedException();
    }


    OptionContract? IOptionContractsRepository.GetOptionContracts(string contractSymbol, long createdTS)
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

    OptionContract IOptionContractsRepository.GetOptionContracts(double strike, long createdTS)
    {
        throw new NotImplementedException();
    }
    List<OptionContract> IOptionContractsRepository.GetOptionContracts(double? strike, long? contractDateStart, long? contractDateEnd, OptionType cp, long? expirationDateStart, long? expirationDateEnd)
    {
        try
        {
            FilterDefinition<OptionContract> cpFilter = Builders<OptionContract>.Filter.Where(x => x.cp == OptionTypeHelper.OptionTypeToString(cp));
            FilterDefinition<OptionContract> combinedFilter = cpFilter;

            combinedFilter = IRepositoryHelper.BuildDateFields(combinedFilter, contractDateStart, contractDateEnd, expirationDateStart, expirationDateEnd);

            if (strike != null)
            {
                FilterDefinition<OptionContract> strikeFilter = Builders<OptionContract>.Filter.Where(x => x.strike == strike);
                combinedFilter &= strikeFilter;
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