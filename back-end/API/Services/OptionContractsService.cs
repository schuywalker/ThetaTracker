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


    public OptionContract GetOptionContracts(string contractSymbol, long createdTS)
    {
        return _repository.GetOptionContracts(contractSymbol, createdTS);
    }
    public OptionContract GetOptionContracts(double strike, long createdTS) // add CP
    {
        return _repository.GetOptionContracts(strike, createdTS);
    }

    public List<OptionContract> GetOptionContracts(double strike, DateTime? queryDateStart, DateTime? queryDateEnd, OptionType cp, DateTime? expirationDateStart, DateTime? expirationDateEnd)
    {
        (long? startQueryTS, long? endQueryTS) = DateManip.GetDayRange(queryDateStart, queryDateEnd);
        (long? expStartTS, long? expEndTS) = DateManip.GetDayRange(expirationDateStart, expirationDateEnd);
        return _repository.GetOptionContracts(strike, startQueryTS, endQueryTS, cp, expStartTS, expEndTS);
    }

}