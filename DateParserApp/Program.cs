using System;
using DateParserLib;

namespace DateParserApp
{
	class Program
	{
		static void Main(string[] args)
		{
			DateParser date = new DateParser(args[0], args[1]);
			Console.WriteLine(date.Compare());
			Console.ReadKey();
		}
	}
}
