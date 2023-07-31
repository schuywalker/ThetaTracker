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
    
    public OptionChain GetOptionChainByDay(string ticker, long date)
    {
        throw new NotImplementedException();
    }

}
