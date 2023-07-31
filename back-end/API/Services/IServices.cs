using API.Models;

namespace API.Services;

public interface IOptionChainService
{
    OptionChain GetOptionChainByDay(string ticker, long date);
}
public interface IOptionContractsService
{
    // IEnumerable<OptionContract> GetOptionContracts(string ticker, string contractSymbol);
    OptionContract GetOptionContracts(string ticker, string contractSymbol, long createdTS);
    // IEnumerable<OptionContract> GetOptionContracts(string ticker, decimal strike);
    OptionContract GetOptionContracts(string ticker, decimal strike, long createdTS);
}



