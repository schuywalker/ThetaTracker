using API.Models;

using API.Utils;

namespace API.Services;

public interface IOptionChainService
{
    OptionChain GetOptionChainByDay(long date);
}
public interface IOptionContractsService
{
    // IEnumerable<OptionContract> GetOptionContracts(string contractSymbol);
    OptionContract? GetOptionContracts(string ticker, string contractSymbol, long createdTS);
    // IEnumerable<OptionContract> GetOptionContracts(double strike);
    OptionContract? GetOptionContracts(string ticker, double strike, long createdTS);
    List<OptionContract> GetOptionContracts(string ticker, double strike, DateTime? queryDateStart, DateTime? queryDateEnd, OptionType cp, DateTime? expirationDateStart, DateTime? expirationDateEnd);
}



