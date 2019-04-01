using System;

namespace DemoApp12
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDocument baseDocument = new BaseDocument("Passport", "4503 139823", DateTimeOffset.Parse("04-12-2015"));

			Passport passport = new Passport("7738421049", DateTimeOffset.Parse("23-09-2010"), "Germany", "Mikhail Alexandrov");

			baseDocument.WriteToConsole();
			Console.WriteLine("\n");
			passport.WriteToConsole();

			BaseDocument[] baseDocuments = new BaseDocument[]
			{
				new Passport("7738421049", DateTimeOffset.Parse("23-09-2010"), "Germany", "Mikhail Alexandrov"),
				new Passport("7738421049", DateTimeOffset.Parse("11-11-2017"), "Germany", "Mikhail Alexandrov"),
				new Passport("7738421049", DateTimeOffset.Parse("14-01-2012"), "Germany", "Mikhail Alexandrov"),
				new BaseDocument("Passport", "4503 139823", DateTimeOffset.Parse("11-12-2015")),
				new BaseDocument("Passport", "4503 139823", DateTimeOffset.Parse("24-12-2015")),
				new BaseDocument("Passport", "4503 139823", DateTimeOffset.Parse("04-12-2015"))
			};

			foreach (BaseDocument currentBaseDocument in baseDocuments)
				if (currentBaseDocument is Passport)
				{
					currentBaseDocument.IssueDate = Passport.ChangeIssueDate(DateTimeOffset.Now);
					currentBaseDocument.WriteToConsole();
				}
			Console.ReadLine();
		}
	}
}
