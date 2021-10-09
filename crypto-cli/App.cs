using CommandLine;
using crypto_cli.Logging;
using crypto_cli.Options;
using crypto_cli.Runners;
using Microsoft.Extensions.Logging;

namespace crypto_cli
{
    public interface IApp
    {
        Task RunAsync(string[] args);
    }

    public class App : IApp
    {
        private readonly ILogger _logger = SharedLogger.CreateLogger<App>();
        public async Task RunAsync(string[] args)
        {
            _logger.LogDebug("{@Arguments}", args);

            await Parser
              .Default
              .ParseArguments<GetOptions>(args)
              .MapResult(
                  async (GetOptions opts) => (await GetRunner.RunGetAndReturnExitCode(opts)),
                  errs => Task.FromResult(1));
        }
    }
}
