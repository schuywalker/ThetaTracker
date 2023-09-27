
using API.Utils;
using API.Models;
using API.Repositories;

namespace API.Services;

public class OptionChainService : IOptionChainService
{
    private readonly IOptionChainRepository _repository;

    public OptionChainService(IOptionChainRepository repository) =>
        _repository = repository;

    public OptionChain GetOptionChainByDay(long date)
    {
        return _repository.GetOptionChainByDay(date);
    }
    // public OptionChain GetOptionChainByDay(DateTime date)
    // {
    //     var (startingTS, endingTS) = DateManip.GetDayRange((DateTime)date, (DateTime)date);
    //     return _repository.GetOptionChainByDayRange(StartOfDay, EndOfDay);
    // }

    public IEnumerable<OptionChain> GetOptionChainsByDayRange(DateTime start, DateTime end)
    {
        // return _repository.GetOptionChainByDayRange(start, end);
        throw new NotImplementedException();
    }

}
