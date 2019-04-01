using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp12
{
	class Passport : BaseDocument 
	{
		public string Country { get; set; }
		public string PersonName { get; set; }

		public Passport(string docNumber, DateTimeOffset issueDate, string country, string personName) 
			: base("Passport", docNumber, issueDate)
		{
			Country = country;
			PersonName = personName;
		}

		public Passport(string docNumber, DateTimeOffset issueDate, string personName)
			: this(docNumber, issueDate)
		{
			PersonName = personName;
		}

		public Passport(string docNumber, DateTimeOffset issueDate)
			: base("Passport", docNumber, issueDate)
		{

		}

		public override string PropertiesString
		{
			get
			{
				return $"Имя докусмента: {DocName}\n" +
						$"Номер документа: {DocNumber}\n" +
						$"Дата выдачи: {IssueDate: dd-MM-yyyy}\n" +
						$"Страна: {Country}\n" +
						$"ФИО: {PersonName}";
			}
		}

		public static DateTimeOffset ChangeIssueDate(DateTimeOffset newIssueDate)
		{
			return DateTimeOffset.Now;
		}
	}
}
