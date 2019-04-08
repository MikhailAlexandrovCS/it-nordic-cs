using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DemoApp14
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public string Category;
		private List<string> _errors;
		public static string OutputPrefixFormat;

		public static string OutputPrefix { get; set; }

		static ErrorList()
		{
			OutputPrefixFormat = "HH:mm:ss";
		}

		public void WriteToConsole()
		{
			foreach (var item in _errors)
				Console.WriteLine(DateTimeOffset.Now.ToString(OutputPrefixFormat) + ": " + Category + ": "
					+ " " + item);
		}

		public void Add(string errorMessage)
		{
			_errors.Add(errorMessage);
		}

		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}

		public void Dispose()
		{
			if (_errors != null)
			{
				_errors.Clear();
				_errors = null;
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			return ((IEnumerable<string>)_errors).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)_errors).GetEnumerator();
		}
	}
}
