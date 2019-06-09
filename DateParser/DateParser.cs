using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateParserLib
{
	public class DateParser
	{
		public DateTime FirstDate{ get; private set; }
		public DateTime SecondDate{ get; private set; }

		public bool DaysAreEqual => FirstDate.Day == SecondDate.Day;
		public bool MonthsAreEqual => FirstDate.Month == SecondDate.Month;
		public bool YearsAreEqual => FirstDate.Year == SecondDate.Year;

		public DateParser(string firstDate, string secondDate)
		{
			if (string.IsNullOrWhiteSpace(firstDate) || string.IsNullOrWhiteSpace(secondDate))
				throw new ArgumentNullException("Arguments needs to be date in format dd.mm.yyyy");

			var firstDateArray = firstDate.Split('.', 3);
			var secondDateArray = secondDate.Split('.', 3);

			try
			{
				FirstDate = new DateTime(Convert.ToInt32(firstDateArray[2]), Convert.ToInt32(firstDateArray[1]), Convert.ToInt32(firstDateArray[0]));
				SecondDate = new DateTime(Convert.ToInt32(secondDateArray[2]), Convert.ToInt32(secondDateArray[1]), Convert.ToInt32(secondDateArray[0]));

			}
			catch (Exception e)
			{
				throw new ArgumentOutOfRangeException("Arguments needs to be date in format dd.mm.yyyy");
			}
		}

		public string Compare()
		{
			var result = new StringBuilder();

			if (!YearsAreEqual)
				result
					.Append(FirstDate.Day.ToString("D2"))
					.Append(".").Append(FirstDate.Month.ToString("D2"))
					.Append(".").Append(FirstDate.Year.ToString("D4"));

			else if (!MonthsAreEqual)
				result
					.Append(FirstDate.Day.ToString("D2"))
					.Append(".").Append(FirstDate.Month.ToString("D2"));

			else if (!DaysAreEqual)
				result
					.Append(FirstDate.Day.ToString("D2"));




			result.Append($" - {SecondDate.ToShortDateString()}");

			return result.ToString();
		}
	}
}
