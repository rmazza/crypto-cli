using crypto_cli;
using crypto_cli.Configuration;
using crypto_cli.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

IConfiguration _config = Config.Instance;
ILogger _logger = SharedLogger.CreateLogger("Program");

try
{
    await new App().RunAsync(args);
}
catch (Exception ex)
{
    _logger.LogError(ex, "Main Catch Block");
}