
using API.Models;
using API.Repositories;

namespace API.Services;

public class OptionChainService : IOptionChainService {
    private readonly IOptionChainRepository _repository;

    public OptionChainService(IOptionChainRepository repository) =>
        _repository = repository;

    public OptionChain GetOptionChainByDay(string ticker, long date)
    {
        return _repository.GetOptionChainByDay(ticker, date);
    }

    

}

// DI is a dependancy that isnt hard coded.
// something that doesn't live on it's own, but waits to say what that thing is.

// problems with hard coded: dependancy could have dependancies, must rewrite for a different implementation, hard to unit test (relies on dependancy)

// solutions: Interface or base class - abstracts dependancy, saying what must be provided by the implementation
// - .Net IServiceProvider thing
// - lastly can be solved through injecting into the constructor.

// ex: interface has attack method, human implements the method because it extends player, which uses that interface. Alien also extends the interface so it has to implement the attack method, but we dont have to rewrite the player class.


// another example
// private readonly IMessageWriter _messageWriter;

    // public Worker(IMessageWriter messageWriter) =>
    //     _messageWriter = messageWriter;

    // then later in a method _messageWriter.Write

