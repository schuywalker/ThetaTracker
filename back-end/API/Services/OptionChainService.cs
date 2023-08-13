
using API.lib.dateManip;
using API.Models;
using API.Repositories;

namespace API.Services;

public class OptionChainService : IOptionChainService
{
    private readonly IOptionChainRepository _repository;

    public OptionChainService(IOptionChainRepository repository) =>
        _repository = repository;

    public OptionChain GetOptionChainByDay(string ticker, long date)
    {
        return _repository.GetOptionChainByDay(ticker, date);
    }
    public OptionChain GetOptionChainByDay(string ticker, DateTime date)
    {

        var dayRange = dateManip.GetDayRange((DateTime)date);
        return _repository.GetOptionChainByDayRange(ticker, dayRange.StartOfDay, dayRange.EndOfDay);
    }

    public IEnumerable<OptionChain> GetOptionChainsByDayRange(string ticker, DateTime start, DateTime end)
    {
        // return _repository.GetOptionChainByDayRange(ticker, start, end);
        throw new NotImplementedException();
    }

}
