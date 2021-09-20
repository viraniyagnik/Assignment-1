using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Assignment_1;


namespace Assignment_1_Tester
{
	[TestClass]
	public class SubsequenceFinderTester
	{
		[TestMethod]
		public void InvalidSubsequence()
		{
			// Implementation here
			var list_1 = new List<int>() { 1, 2, 3, 4, 5, 6, };
			var list_2 = new List<int>() { 8, 9 };

			SubsequenceFinder.ContainsSubsequence(list_1, list_2);

			Assert.IsTrue(true);
		}
		[TestMethod]
		public void ValidSubsequence()
		{
			// Implementation here
			var list_1 = new List<int>() { 1, 2, 3, 4, 5, 6, };
			var list_2 = new List<int>() { 5, 6 };

			SubsequenceFinder.ContainsSubsequence(list_1, list_2);

			Assert.IsTrue(true);
		}
	}

}
