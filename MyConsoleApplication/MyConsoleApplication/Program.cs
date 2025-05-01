using Microsoft.Extensions.DependencyInjection;

namespace MyConsoleApplication
{
	interface ILogger
	{
		void Log(string message);
	}
	class Logger : ILogger
	{
		public void Log(string message)
		{
            Console.WriteLine(message);
        }
	}
	class BeautifulLogger : ILogger
	{
		public void Log(string message)
		{
            Console.WriteLine($"[{DateTime.Now}] Beautiful logger : {message}");
        }
	}
	interface IDatabase
	{
		void SaveOrder();
	}
	class PostgresDatabase : IDatabase
	{
		private readonly ILogger _logger;
		public PostgresDatabase(ILogger logger)
		{
			_logger = logger;
		}
		public void SaveOrder()
		{
            _logger.Log("Postgres Database : Processing order...");
        }
	}
	class MySQLDatabase : IDatabase
	{
		private readonly ILogger _logger;
		public MySQLDatabase(ILogger logger)
		{
			_logger = logger;
		}
		public void SaveOrder()
		{
			_logger.Log("MySQL Database : Processing order...");
		}

	}
	class OrderService
	{
		private readonly ILogger _logger;
		private readonly IDatabase _database;
		public OrderService(ILogger logger, IDatabase database)
		{
			_logger = logger;
			_database = database;
		}
		public void ProcessOrder()
		{
            
			_logger.Log("Start processing order...");
			_database.SaveOrder();
			_logger.Log("Order processing finished");
        }
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			IServiceCollection services = new ServiceCollection();
			services.AddSingleton<ILogger, BeautifulLogger>();
			services.AddSingleton<IDatabase, PostgresDatabase>();
			services.AddSingleton<OrderService>();

			/*Logger logger = new Logger();
			BeautifulLogger beautifulLogger = new BeautifulLogger();
			PostgresDatabase postgresDatabase = new PostgresDatabase(logger);
			//MySQLDatabase mySQLDatabase = new MySQLDatabase(beautifulLogger);

			OrderService orderService = new OrderService(beautifulLogger, postgresDatabase);
			orderService.ProcessOrder();
			orderService.ProcessOrder();
			orderService.ProcessOrder();
			orderService.ProcessOrder();
			orderService.ProcessOrder();*/

			IServiceProvider serviceProvider = services.BuildServiceProvider();
			OrderService orderService = serviceProvider.GetRequiredService<OrderService>();
			orderService.ProcessOrder();
		}
	}
}
