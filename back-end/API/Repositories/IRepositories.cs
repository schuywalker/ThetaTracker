using API.lib;
using API.Models;

namespace API.Repositories;

/*
repositories hold the logic for interacting with the database so that this logic can 
be separated from the business logic (how we use the data).
*/

public interface IOptionChainRepository
{
    OptionChain GetOptionChainByDay(string ticker, long createdTS);
    public OptionChain GetOptionChainByDayRange(string ticker, long start, long end);
}

public interface IOptionContractsRepository
{
    // IEnumerable<OptionContract> GetOptionContracts(string ticker, string contractSymbol);
    OptionContract GetOptionContracts(string ticker, string contractSymbol, long createdTS);
    // IEnumerable<OptionContract> GetOptionContracts(string ticker, decimal strike);
    OptionContract GetOptionContracts(string ticker, double strike, long createdTS);
    List<OptionContract> GetOptionContracts(string ticker, double strike, long start, long end, OptionType cp, long? expirationDateStart, long? expirationDateEnd);

}