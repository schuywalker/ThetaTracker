//using API.lib.dateManip;
using API.Utils;
using API.Models;
using MongoDB.Driver;

namespace API.Repositories;

public class OptionChainRepository : IOptionChainRepository
{
    private readonly IMongoCollection<OptionChain> _collection;

    public OptionChainRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<OptionChain>(collectionName);
    }

    public OptionChain GetOptionChainByDay(long date)
    {
        throw new NotImplementedException();
    }
    public OptionChain GetOptionChainByDay(DateTime date)
    {
        (long? startQueryTS, long? endQueryTS) = DateManip.GetDayRange((DateTime)date, (DateTime)date);
        return GetOptionChainByDayRange(startQueryTS, endQueryTS);
    }
    public OptionChain GetOptionChainByDayRange(long? start, long? end)
    {
        throw new NotImplementedException();
    }


}
