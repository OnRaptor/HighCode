namespace HighCode.Application.Runners;

public class RunnerFactory
{
    private readonly IEnumerable<IRunner> runners;

    public RunnerFactory(IEnumerable<IRunner> runners)
    {
        this.runners = runners;
    }

    public IRunner? GetRunnerByLanguage(string name)
        => runners.FirstOrDefault(r => r.ProgrammingLanguage.ToLower().Contains(name.ToLower()));
    
}