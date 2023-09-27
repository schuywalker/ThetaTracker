
using MongoDB.Driver;

namespace API.Repositories;

public interface IOptionContractsRepositoryFactory
{
    IOptionContractsRepository Create(string ticker);
}

public class OptionContractsRepositoryFactory : IOptionContractsRepositoryFactory
{
    private readonly IMongoDatabase _database;

    public OptionContractsRepositoryFactory(IMongoDatabase database)
    {
        _database = database;
    }

    public IOptionContractsRepository Create(string ticker)
    {
        return new OptionContractsRepository(_database, ticker);
    }

    
}