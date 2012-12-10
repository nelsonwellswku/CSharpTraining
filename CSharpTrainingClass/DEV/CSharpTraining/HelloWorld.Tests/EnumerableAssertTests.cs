using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HelloWorld.Tests
{
    /// <summary>
    /// Summary description for EnumerableAssertTests
    /// </summary>
    [TestClass]
    public class EnumerableAssertTests
    {
        string[] Keywords = {
                                "abstract","add*","alias*","as","ascending*","async*","await*","base"
                                ,"bool","break","by*","byte","case","catch","char","checked","class"
                                ,"const","continue","decimal","default","delegate","descending*","do"
                                ,"double","dynamic*","else","enum","equals*","event","explicit"
                                ,"extern","false","finally","fixed","float","for","foreach","from*"
                                ,"get*","global*","goto","group*","if","implicit","in","int","interface"
                                ,"internal","into*","is","join*","let*","lock","long","namespace","new"
                                ,"null","object","on*","operator","orderby*","out","override","params"
                                ,"partial*","private","protected","public","readonly","ref","remove*"
                                ,"return","sbyte","sealed","select*","set*","short","sizeof","stackalloc"
                                ,"static","string","struct","switch","this","throw","true","try","typeof"
                                ,"uint","ulong","unchecked","unsafe","ushort","using","value*","var*"
                                ,"virtual","void","volatile","where*","while","yield*" 
                            };

        [TestMethod]
        public void AreEquivalent_IdenticalItems_Succeeds()
        {
            Keywords.AreEquivalent(Keywords);
            Keywords.Select(item => item.Length).AreEquivalent(Keywords.Select(item => item.Length));
            Keywords.Select(item => item.Length).Reverse().AreEquivalent(Keywords.Select(item => item.Length));
            string[] items = new string[0];
            items.AreEquivalent(new string[0]);
        }

        [TestMethod]
        public void AreEquivalent_ReverseItems_Succeeds()
        {
            Keywords.Select(item => item.Length).Reverse().AreEquivalent(Keywords.Select(item => item.Length));
        }

        [TestMethod]
        [ExpectedException(typeof(InternalTestFailureException))]
        public void AreEquivalent_OneEmptyCollectionItems_Asserts()
        {
            try
            {
                Keywords.Reverse().AreEquivalent(new string[0]);
            }
            catch (AssertFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("different number of items"));
                throw new InternalTestFailureException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InternalTestFailureException))]
        public void AreEquivalent_AdditionalItemCollectionInSecond_Asserts()
        {
            try
            {
                Keywords.Reverse().AreEquivalent(
                    Keywords.Union(new string[]{"fake"}));
            }
            catch (AssertFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Assert.AreEqual failed."), exception.Message);
                throw new InternalTestFailureException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InternalTestFailureException))]
        public void AreEquivalent_AdditionalItemCollectionInFirst_Asserts()
        {
            try
            {
                Keywords.Union(new string[] { "fake" }).Reverse().AreEquivalent(
                    Keywords);
            }
            catch (AssertFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Assert.AreEqual failed."), exception.Message);
                throw new InternalTestFailureException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InternalTestFailureException))]
        public void AreEquivalent_DifferentFirstItemCollectionItems_Asserts()
        {
            try
            {
                Keywords.Union(new string[] { "one" }).Reverse().AreEquivalent(
                    Keywords.Union(new string[] { "two" }));
            }
            catch (AssertFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Assert.AreEqual failed."), exception.Message);
                throw new InternalTestFailureException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InternalTestFailureException))]
        public void AreEquival_ReverseCollectionItems_Asserts()
        {
            try
            {
                Keywords.Reverse().AreEqual(Keywords);
            }
            catch (AssertFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Assert.AreEqual failed."), exception.Message);
                throw new InternalTestFailureException();
            }
        }
    }
}
