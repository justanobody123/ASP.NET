using System.Security.Cryptography.X509Certificates;

namespace AnotherConsoleApplication
{
	//SOLID
	//
	//S - Single Responsibility Principle (SRP)
	//Модуль должен отвечать только за одного актора. Класс должен отвечать только за одну задачу.
	//Зачем: чтобы изменения в одной части логики программы не ломали другие.

	//Плохой пример:
	class Report_BadSoluion
	{
		public string? Text { get; set; }
		public void Print()
		{
			Console.WriteLine(Text);
		}
		public void SaveToFile(string filePath)
		{
			//...
		}
	}
	//----------------------------------------------------------------------
	//Хороший пример:
	class Report
	{
		private string _text;
		public string GetText()
		{
			return _text;
		}
		public void SetText(string text) 
		{
			_text = text;
		}
	}
	class ReportPrinter
	{
		public void Print(Report report)
		{
            Console.WriteLine(report.GetText());
        }
	}
	class ReportSaver()
	{
		public void SaveToFile(Report report, string filepath)
		{
			//...
		}
	}
	//O - Open/Closed Principle
	//Программные сущности (классы) должны быть открыты для расширения, но закрыты для модификации.
	//Зачем: чтобы можно было добавлять новую функциональность, не трогая существующий код
	//Не переписывать существующий код, а добавлять новый
	
	//Плохой пример:
	class NotificationService_BadSolution
	{
		public void SendNotification(string message, string type)
		{
			if (type == "Email")
			{
                Console.WriteLine("Email: ...");
            }
			else if (type == "SMS")
			{
                Console.WriteLine("SMS: ...");
            }
			else if (type == "WhatsApp")
			{
                Console.WriteLine("WhatsApp: ...");
            }
			else if (type == "Telegram")
			{
                Console.WriteLine("Telegram: ...");
            }
		}
	}
	//Хороший пример
	interface INotifier
	{
		void SendNotification(string message)
		{
			
		}
	}
	class EmailNotifier : INotifier
	{
		public void SendNotification(string message)
		{
            //Sending email
        }
	}
	class SMSNotifier : INotifier
	{
		public void SendNotification(string message)
		{
			//Sending SMS
		}
	}
	class NotificationService
	{
		private readonly INotifier _notifier;
		public NotificationService(INotifier notifier)
		{
			_notifier = notifier;
		}
		public void SendNotification(string message)
		{
			_notifier.SendNotification(message);
		}
	}
	//
	//L - Liskov Substitution Principle (принцип подстановки Лисков)
	//Функции, которые используют базовый тип, должны иметь возможность использовать подтипы базового типа, не зная об этом.
	//Подкласс должен вести себя как родительский класс, не ломая логику.
	//Зачем: чтобы было легко заменить родителя на потомка класса
	//

	//Плохой пример:
	class Bird_BadSolution
	{
		public virtual void Fly()
		{
            Console.WriteLine("Flying...");
        }
	}
	class Penguin_BadSolution : Bird_BadSolution
	{
		public override void Fly()
		{
            Console.WriteLine("Penguins can't fly.");
        }
		
	}
	//Хороший пример:
	class Bird
	{
		public virtual void Eat()
		{
            Console.WriteLine("Bird is eating...");
        }
	}
	interface IFlyable
	{
		void Fly();
	}
	class Pigeon : Bird, IFlyable
	{
		public void Fly()
		{
            Console.WriteLine("Pigeon is flying...");
        }
	}
	class Penguin : Bird
	{

	}
	//
	//I - Interface Segregation Principle (ISP) Принцип разделения интерфейса.
	//Много интерфейсов, специально предназначенных для клиента, лучше, чем один интерфейс общего назначения.
	//Идея: не заставляем класс реализовывать ненужные методы
	//Зачем: чтобы сделать классы простыми и понятными

	//Плохой пример:
	interface IWorker_BadSolution
	{
		void Work();
		void Eat();
	}
	class Employee_BadSolution : IWorker_BadSolution
	{
		public void Eat()
		{
			//Employee is eating...
		}
		public void Work()
		{
			//Employee is working...
		}
	}
	class Robot_BadSolution : IWorker_BadSolution
	{
		public void Eat()
		{
			//Ненужный метод
		}
		public void Work()
		{
			//Robot is working...
		}
	}
	//Хороший пример 
	interface IWorkable
	{
		void Work();
	}
	interface IFeedable
	{
		void Eat();
	}
	class Employee : IWorkable, IFeedable
	{
		public void Eat()
		{
            //Eating...
        }
		public void Work()
		{
			//Working...
		}
	}
	class Robot : IWorkable
	{
		public void Work()
		{
			//Working...
		}
	}
	//
	//D - Dependency Inversion Principle (DIP) Принцип инверсии зависимостей
	//
	//Зависимость на абстракциях. Нет зависимостей на что-то конкретное.
	//Идея: зависимости должны быть абстрактными, а не конкретными.
	//Зачем: Чтобы можно было легко менять детали реализации

	//Плохой пример:
	class ConsoleLogger_BadSolution
	{
		public void Log(string message)
		{
            Console.WriteLine(message);
        }
	}
	class FileLogger_BadSolution
	{
		public void Log(string message)
		{
			File.WriteAllText("log.txt", message);
		}
	}
	class OrderService_BadSolution
	{
		private readonly ConsoleLogger_BadSolution _consoleLogger = new ConsoleLogger_BadSolution();
		public void ProcessOrder()
		{
			_consoleLogger.Log("Order processed.");
		}
	}

	//Хороший пример:
	interface ILogger
	{
		void Log(string message);
	}
	class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
            Console.WriteLine(message);
        }
	}
	class FileLogger : ILogger
	{
		public void Log(string message)
		{
			File.WriteAllText("log.txt", message);
		}
	}
	class OrderService
	{
		private readonly ILogger _logger;
        public OrderService(ILogger logger)
        {
			_logger = logger;
        }
		public void ProcessOrder()
		{
			_logger.Log("Order processed.");
		}
    }
	internal class Program
	{
		static void Main(string[] args)
		{
			ILogger logger = new ConsoleLogger();
			OrderService orderService = new OrderService(logger);
			orderService.ProcessOrder();
		}
	}
}
