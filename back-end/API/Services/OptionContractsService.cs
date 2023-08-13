using System.Reflection;
using API.lib;
using API.lib.dateManip;
using API.Models;
using API.Repositories;

namespace API.Services;

public class OptionContractsService : IOptionContractsService
{

    private readonly IOptionContractsRepository _repository;

    public OptionContractsService(IOptionContractsRepository repository) =>
        _repository = repository;


    public OptionContract GetOptionContracts(string ticker, string contractSymbol, long createdTS)
    {
        return _repository.GetOptionContracts(ticker, contractSymbol, createdTS);
    }
    public OptionContract GetOptionContracts(string ticker, double strike, long createdTS) // add CP
    {
        return _repository.GetOptionContracts(ticker, strike, createdTS);
    }

    public List<OptionContract> GetOptionContracts(string ticker, double strike, DateTime date, OptionType cp, DateTime? expirationDate)
    {
        (long start, long end) = dateManip.GetDayRange(date);
        (long? expStart, long? expEnd) = (expirationDate != null) ? dateManip.GetDayRange((DateTime)expirationDate) : ((long?)null, (long?)null);
        return _repository.GetOptionContracts(ticker, strike, start, end, cp, expStart, expEnd);
    }

}