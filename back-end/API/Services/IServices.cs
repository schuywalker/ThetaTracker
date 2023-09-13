using API.Models;

using API.lib;

namespace API.Services;

public interface IOptionChainService
{
    OptionChain GetOptionChainByDay(long date);
}
public interface IOptionContractsService
{
    // IEnumerable<OptionContract> GetOptionContracts(string contractSymbol);
    OptionContract GetOptionContracts(string contractSymbol, long createdTS);
    // IEnumerable<OptionContract> GetOptionContracts(double strike);
    OptionContract GetOptionContracts(double strike, long createdTS);
    List<OptionContract> GetOptionContracts(double strike, DateTime? queryDateStart, DateTime? queryDateEnd, OptionType cp, DateTime? expirationDateStart, DateTime? expirationDateEnd);
}



