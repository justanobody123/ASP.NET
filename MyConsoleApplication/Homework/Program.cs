using Microsoft.Extensions.DependencyInjection;

namespace Homework
{
	interface ILogger
	{
		void Log(string message);
	}
	interface IMusic
	{
		string GetGenre();
	}
	class ClassicalMusic : IMusic
	{
		public string GetGenre()
		{
			return "Classical";
		}
	}
	class MusicPlayer
	{
		private readonly ILogger _logger;
		private readonly IMusic _music;
		public MusicPlayer(ILogger logger, IMusic music)
		{
			_logger = logger;
			_music = music;
		}
		public void PlayMusic()
		{
			_logger.Log($"Playing {_music.GetGenre()} music");
		}
	}
	class ConsoleLogger : ILogger
	{
		public void Log(string message) 
		{
            Console.WriteLine(message);
        }
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			ServiceCollection services = new ServiceCollection();
			services.AddSingleton<ILogger, ConsoleLogger>();
			services.AddSingleton<IMusic, ClassicalMusic>();
			services.AddSingleton<MusicPlayer>();
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			serviceProvider.GetRequiredService<MusicPlayer>().PlayMusic();
		}
	}
}
