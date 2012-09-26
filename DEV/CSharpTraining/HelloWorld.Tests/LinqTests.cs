using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class LinqTests
    {

        private IEnumerable<int> Numbers =
            new List<int>(){1,2,3,4,5,6,7,8,9};

        private IEnumerable<string> keywords = 
            new List<string>{"public", "void", "private", "return", "..."};
                                                

        [TestMethod]
        public void Where_ItemsAreEven()
        {
            IEnumerable<int> gooses = Numbers.Where((int x) => x % 2 == 0);
            Assert.AreEqual<int>(4, gooses.Count());
            Assert.IsTrue(gooses.All(x => x % 2 == 0));
        }

        [TestMethod]
        public void Select_2ndLetter()
        {
            List<char> meeses = keywords.Select((string x) => x[1]).ToList();
        
            CollectionAssert.AreEquivalent(new char[] {'u', 'o', 'r', 'e', '.' }, meeses);

        }

        //[TestMethod]
        //[ExpectedException(typeof(AssertFailedException))]
        //public void Select_2ndLetter_HomeMade()
        //{
        //    IEnumerable<char> meeses = keywords.Select((string x) => x[1]);
        //    meeses.AssertAreEquivalent(
        //        new char[] { 'x', 'o', 'r', 'e', '.' }
        //    );

        //}




        [TestMethod]
        public void Select_EvenIndexedKeywords_Length()
        {
            int phil = 0;
            List<int> actual = keywords
                .Where(
                    (string s) => phil++ % 2 == 0
                )
                .Select<string,int>(
                    (string s) => s.Length
                ).ToList();

            int[] expected= new int[] { 6, 7, 3 };

            Assert.AreEqual<int>(expected.Length,
                actual.Count());

            for (int counter = 0; counter < expected.Count(); counter++)
			{
			    Assert.AreEqual<int>(
                    expected[counter], actual[counter]);
			}
        }

        [TestMethod]
        public void Select_LengthAndFirstCharacterOfKeywords_Length()
        {
            var actual = keywords
                .Select(item=>
                    new {
                        item.Length,
                        FirstLetter=item[0]
                    }).ToList();

            var expected = new[] 
                { 
                    new {Length=6, FirstLetter='p'},
                    new {Length=4, FirstLetter='v'},
                    new {Length=7, FirstLetter='p'},
                    new {Length=6, FirstLetter='r'},
                    new {Length=3, FirstLetter='.'},
                };
                    

            Assert.AreEqual<int>(expected.Length,
                actual.Count());

            for (int counter = 0; counter < expected.Count(); counter++)
            {
                Assert.AreEqual<int>(
                    expected[counter].Length, actual[counter].Length);
                Assert.AreEqual<char>(
                    expected[counter].FirstLetter, actual[counter].FirstLetter);
            }
        }

        [TestMethod]
        public void DeferedExection()
        {
            int counter = 0;
            IEnumerable<string> query =
                keywords.Where(item=>
                    {
                        counter++;
                        return true;
                    });

            query = query.Where(item =>
                {
                    counter++;
                    return item.Length < 6;
                });
            Assert.AreEqual<int>(
                0, counter);

            foreach (string item in query)
            {
            }

            Assert.AreEqual<int>(
                2*keywords.Count(), counter);
            query.Take(10);
            query.ToList().Count();

        }
    }
}
