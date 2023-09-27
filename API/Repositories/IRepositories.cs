using API.Utils;
using API.Models;
using MongoDB.Driver;

namespace API.Repositories;

/*
repositories hold the logic for interacting with the database so that this logic can 
be separated from the business logic (how we use the data).
*/

public interface IOptionChainRepository
{
    OptionChain GetOptionChainByDay(long createdTS);
    // public OptionChain GetOptionChainByDayRange(long? start, long? end);
}

public interface IOptionContractsRepository
{
    // IEnumerable<OptionContract> GetOptionContracts(string contractSymbol);
    OptionContract? GetOptionContracts(string contractSymbol, long createdTS);
    // IEnumerable<OptionContract> GetOptionContracts(decimal strike);
    OptionContract? GetOptionContracts(double strike, long createdTS);
    List<OptionContract> GetOptionContracts(double? strike, long? start, long? end, OptionType cp, long? expirationDateStart, long? expirationDateEnd);

}

public class IRepositoryHelper
{
    public static FilterDefinition<OptionContract> BuildDateFields(FilterDefinition<OptionContract> combinedFilter, long? contractDateStart, long? contractDateEnd, long? expirationDateStart, long? expirationDateEnd)
    {
        if (contractDateStart != null)
        {
            combinedFilter &= Builders<OptionContract>.Filter.Gte(x => x.createdTS, contractDateStart);
        }
        if (contractDateEnd != null)
        {
            combinedFilter &= Builders<OptionContract>.Filter.Lte(x => x.createdTS, contractDateEnd);
        }
        if (expirationDateStart != null)
        {
            combinedFilter &= Builders<OptionContract>.Filter.Gte(x => x.expirationDateTS, expirationDateStart);
        }
        if (expirationDateEnd != null)
        {
            combinedFilter &= Builders<OptionContract>.Filter.Lte(x => x.expirationDateTS, expirationDateEnd);
        }
        return combinedFilter;
    }
}