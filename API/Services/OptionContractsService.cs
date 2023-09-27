using System.Reflection;
using API.Utils;
// using API.lib.dateManip;
using API.Models;
using API.Repositories;

namespace API.Services;

public class OptionContractsService : IOptionContractsService
{
    private readonly IOptionContractsRepositoryFactory _repoFactory;
    

    public OptionContractsService(IOptionContractsRepositoryFactory repoFactory) =>
        _repoFactory = repoFactory;


    public OptionContract? GetOptionContracts(string ticker, string contractSymbol, long createdTS)
    {
        var _repository = _repoFactory.Create(ticker);
        return _repository.GetOptionContracts(contractSymbol, createdTS);
    }
    public OptionContract? GetOptionContracts(string ticker, double strike, long createdTS) // add CP
    {
        var _repository = _repoFactory.Create(ticker);
        return _repository.GetOptionContracts(strike, createdTS);
    }

    public List<OptionContract> GetOptionContracts(string ticker, double strike, DateTime? queryDateStart, DateTime? queryDateEnd, OptionType cp, DateTime? expirationDateStart, DateTime? expirationDateEnd)
    {
        var _repository = _repoFactory.Create(ticker);
        (long? startQueryTS, long? endQueryTS) = DateManip.GetDayRange(queryDateStart, queryDateEnd);
        (long? expStartTS, long? expEndTS) = DateManip.GetDayRange(expirationDateStart, expirationDateEnd);
        return _repository.GetOptionContracts(strike, startQueryTS, endQueryTS, cp, expStartTS, expEndTS);
    }

}