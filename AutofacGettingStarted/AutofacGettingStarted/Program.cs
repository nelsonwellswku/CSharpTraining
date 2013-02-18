using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoApp;
using Autofac;

namespace AutofacGettingStarted
{
	class Program
	{
		private static IContainer _container;

		static void Main(string[] args)
		{
			// Create the autofac builder
			var builder = new ContainerBuilder();

			// Register our type
			builder.RegisterType<ConsoleOutput>().As<IOutput>();
			builder.RegisterType<TodayWriter>().As<IDateWriter>();

			// Put them into our container
			_container = builder.Build();

			WriteDate();
			Console.ReadKey();
		}

		public static void WriteDate()
		{
			// Creat the scope, resolve IDateWriter,
			// use it, then dispose of the scope
			using (var scope = _container.BeginLifetimeScope())
			{
				var writer = scope.Resolve<IDateWriter>();
				writer.WriteDate();
			}
		}
	}
}
