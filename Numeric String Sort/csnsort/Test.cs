using System;
using System.Collections;

using ns;

public class Test
{
	public static void Main(string[] args)
	{

		string[] files = new string[] {
			"a", "a",
			"1.txt", "_1.txt",
			"[1.txt", "=1.txt",
			"10.txt", "3.txt",
			"a10b1.txt", "a1b1.txt",
			"a2b1.txt", "a2b11.txt",
			"a2b2.txt", "b1.txt",
			"b10.txt", "b2.txt",
			"b[1.txt", "b01.txt",
			"c30.txt", "c25.txt",
			"c35.txt", "c40.txt",
			"BIG.txt", "big.txt",
			"001", "01", "1", "002", "02", "2", "03", "3", "004", "4"};

		try{

			Array.Sort(files, StringLogicalComparer.Default);
			foreach(string file in files)
			{
				Console.WriteLine(file);
			}

			// or
			Console.WriteLine("--- zeroes first ---");
			Console.WriteLine(string.Empty);

			Array.Sort(files, StringLogicalComparer.DefaultZeroesFirst);
			foreach(string file in files)
			{
							Console.WriteLine(file);
			}

		}catch(Exception ex)
		{
			Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
		}
	}
}