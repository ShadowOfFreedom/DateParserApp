using System;
using DateParserLib;
using NUnit.Framework;

namespace DateParserUnitTests
{
	public class TeDateParserClassTestssts
	{

		DateTime testDate1 = new DateTime(2017, 1, 1);
		DateTime testDate2 = new DateTime(2017, 1, 5);

		private const string expectedDateString1 = "01 - 05.01.2017";
		private const string expectedDateString2 = "01.01 - 05.02.2017";
		private const string expectedDateString3 = "01.01.2016 - 05.01.2017";
		private const string expectedDateString4 = "05.01.2017";
		
		[Test]
		public void DateParserConstructorFirstArgumentWithValidDataTest()
		{
			var dateParser = new DateParser("01.01.2017", "05.01.2017");

			Assert.AreEqual(testDate1,dateParser.FirstDate);
		}

		[Test]
		public void DateParserConstructorSecondArgumentWithValidDataTest()
		{
			var dateParser = new DateParser("01.01.2017", "05.01.2017");

			Assert.AreEqual(testDate2, dateParser.SecondDate);
		}

		[Test]
		public void DateParserConstructorWithInvalidDataTest()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new DateParser("dd.mm.yyyy", "dd.mm.yyyy"));
		}

		[Test]
		public void DateParserConstructorWithNullDataTest()
		{
			Assert.Throws<ArgumentNullException>(() => new DateParser(null, ""));
		}

		[Test]
		public void DateParseCompareMethodCorrectlyCompareYearAndMonthTest()
		{
			var dateParser = new DateParser("01.01.2017", "05.01.2017");

			Assert.AreEqual(expectedDateString1, dateParser.Compare());
		}

		[Test]
		public void DateParseCompareMethodCorrectlyCompareMonthTest()
		{
			var dateParser = new DateParser("01.01.2017", "05.02.2017");

			Assert.AreEqual(expectedDateString2, dateParser.Compare());
		}

		[Test]
		public void DateParseCompareMethodCorrectlyReturnsFullStringTest()
		{
			var dateParser = new DateParser("01.01.2016", "05.01.2017");

			Assert.AreEqual(expectedDateString3, dateParser.Compare());
		}

		[Test]
		public void DateParseCompareMethodCorrectlyCompareYearAndMonthAndDayTest()
		{
			var dateParser = new DateParser("05.01.2017", "05.01.2017");

			Assert.AreEqual(expectedDateString4, dateParser.Compare());
		}
	}
}