using HelloWorld.Interfaces;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Grains;

public class HelloArchiveGrain : Grain<GreetingArchive>, IHelloArchive
{
    public async Task<string> SayHello(string greeting)
    {
        this.State.Greetings.Add(greeting);

        await this.WriteStateAsync();

        return $"You said: '{greeting}', I say: Hello!";
    }

    public Task<IEnumerable<string>> GetGreetings()
    {
        return Task.FromResult<IEnumerable<string>>(this.State.Greetings);
    }
}

public class GreetingArchive
{
    public List<string> Greetings { get; } = new List<string>();
}