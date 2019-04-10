using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp15
{
	class Account<T>
	{
		public string Name { get; private set; }
		public T Id { get; private set; }

		public Account(string name, T id)
		{
			Name = name;
			Id = id;
		}

		public void WriteProperties()
		{
			Console.Write($"Name: {Name}\n" +
				$"Id: {Id}\n");
		}
	}
}
