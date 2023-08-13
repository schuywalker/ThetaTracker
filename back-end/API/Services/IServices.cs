using API.Models;

using API.lib;

namespace API.Services;

public interface IOptionChainService
{
    OptionChain GetOptionChainByDay(string ticker, long date);
}
public interface IOptionContractsService
{
    // IEnumerable<OptionContract> GetOptionContracts(string ticker, string contractSymbol);
    OptionContract GetOptionContracts(string ticker, string contractSymbol, long createdTS);
    // IEnumerable<OptionContract> GetOptionContracts(string ticker, double strike);
    OptionContract GetOptionContracts(string ticker, double strike, long createdTS);
    List<OptionContract> GetOptionContracts(string ticker, double strike, DateTime dayRange, OptionType cp, DateTime? expirationDate);
}



