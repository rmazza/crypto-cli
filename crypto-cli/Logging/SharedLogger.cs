using Microsoft.Extensions.Logging;
using Serilog;

namespace crypto_cli.Logging
{
    public static class SharedLogger
    {
        //public static readonly ILoggerFactory _loggerFactory;
       
        //static SharedLogger()
        //{
        //    Log.Logger = new LoggerConfiguration()
        //        .Enrich.FromLogContext()
        //        .WriteTo.Console()
        //        .MinimumLevel.Debug()
        //        .CreateLogger();
        //    _loggerFactory = LoggerFactory.Create(o => o.AddSerilog());
        //}

		private static ILoggerFactory _Factory = null;

		public static void ConfigureLogger(ILoggerFactory factory)
		{
			Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();
            factory.AddSerilog();
		}

		public static ILoggerFactory LoggerFactory
		{
			get
			{
				if (_Factory == null)
				{
					_Factory = new LoggerFactory();
					ConfigureLogger(_Factory);
				}
				return _Factory;
			}
			set { _Factory = value; }
		}
		public static Microsoft.Extensions.Logging.ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
		public static Microsoft.Extensions.Logging.ILogger CreateLogger(string category) => LoggerFactory.CreateLogger(category);
	}
}
