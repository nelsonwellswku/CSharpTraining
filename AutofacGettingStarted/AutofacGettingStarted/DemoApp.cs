using System;

namespace DemoApp
{
	// We don't care how the write operation happens, just that we can write
	public interface IOutput
	{
		void Write(string content);
	}

	// The implementation writes to the console, though it could write to a file,
	// database, log, or whatever else
	public class ConsoleOutput : IOutput
	{
		public void Write(string content)
		{
			Console.WriteLine(content);
		}
	}

	public interface IDateWriter
	{
		void WriteDate();
	}

	public class TodayWriter : IDateWriter
	{
		private IOutput _output;
		
		public TodayWriter(IOutput output)
		{
			this._output = output;
		}

		public void WriteDate()
		{
			this._output.Write(DateTime.Today.ToShortDateString());
		}
	}
}