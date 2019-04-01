using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp12
{
	class BaseDocument
	{
		public string DocName { get; set; }
		public string DocNumber { get; set; }
		public DateTimeOffset IssueDate { get; set; }

		public virtual string PropertiesString
		{
			get
			{
				return $"Имя докусмента: {DocName}\n" +
						$"Номер документа: {DocNumber}\n" +
						$"Дата выдачи: {IssueDate : dd-MM-yyyy}";
			}
		}

		public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
		{
			DocName = docName;
			DocNumber = DocNumber;
			IssueDate = IssueDate;
		}

		public void WriteToConsole()
		{
			Console.Write($"\n{PropertiesString}");
		}
	}
}
