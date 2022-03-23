//driver code
using System;
using System.IO;

namespace String_To_Lower{
	public class Program{
		public static void Main(string[] args){
			Solution s = new Solution();


			List<char> charArr = args[0].Split(' ').Select(a => Convert.ToChar(a)).ToList();

			var lower = s.solve(charArr);
			foreach (char item in lower)
			{
				Console.Write(item + " ");
			}
			
		}
	}
}
