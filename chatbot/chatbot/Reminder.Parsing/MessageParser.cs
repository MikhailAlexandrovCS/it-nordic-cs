using System;
using System.Globalization;

namespace Reminder.Parsing
{
	public static class MessageParser
	{
		public static ParsedMessage Parse(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				return null;

			int firstSpacePosition = message.IndexOf(" ");
			if (firstSpacePosition <= 0)
				return null;
            string[] words = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			//string firstWord = message.Substring(0, firstSpacePosition);
            string firstWord = words[0] + " " + words[1] + " " + words[2];
            //DateTimeOffset date = DateTime.Now;
            DateTimeOffset date = DateTimeOffset.Parse(firstWord);
            string otherMessage = null;
            for (int i = 3; i < words.Length; i++)
                otherMessage += words[i] + " ";
			//bool dateIsOk = DateTimeOffset.TryParse(firstWord, out var date);
			//if (!dateIsOk)
			//	return null;

			return new ParsedMessage
			{
				Date = date,
				Message = otherMessage.Trim()
			};
		}
	}
}
