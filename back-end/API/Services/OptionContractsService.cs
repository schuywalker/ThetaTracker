using API.Models;
using API.Repositories;

namespace API.Services;

public class OptionContractsService : IOptionContractsService
{

    private readonly IOptionContractsRepository _repository;

    public OptionContractsService(IOptionContractsRepository repository) =>
        _repository = repository;  // injected way of dealing with db.


    public OptionContract GetOptionContracts(string ticker, string contractSymbol, long createdTS)
    {
        return _repository.GetOptionContracts(ticker, contractSymbol, createdTS);
    }
    public OptionContract GetOptionContracts(string ticker, decimal strike, long createdTS) // add CP
    {
        return _repository.GetOptionContracts(ticker, strike, createdTS);
    }




    // public IEnumerable<OptionContract> GetOptionContract(string ticker, string contractSymbol)
    // {
    //     return _repository.GetOptionContract(ticker, contractSymbol);
    // }
    // public OptionContract GetOptionContract(string ticker, decimal strike)
    // {
    //     return _repository.GetOptionContract(ticker, strike);
    // }

}