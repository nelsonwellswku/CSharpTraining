using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Main_EverythingIsHunkyDory_Success()
        {
            /*string[] args = {"42", "second"};
            IntelliTect.ConsoleView.Tester.Test(
                    "Hello, My name is....", () =>
                Program.Main(args)
            );*/
        }

        [TestMethod]
        public void Main_Normal_Return42()
        {
            Assert.AreEqual<int>(42, Program.Main(new string[] { "42" }));
        }

        [TestMethod]
        public void Verify_Initialize_Success()
        {
            string text = "Inigo Montoya";

            text = Initialize();

            Assert.AreEqual<string>(
                null, text);

            text = Initialize("Inigo Montoya");

            Assert.AreEqual<string>(
                "Inigo Montoya", text);

        }

        private static string Initialize(
            string text = null)
        {
            return text;
        }

        [TestMethod]
        public void Swap_FirstAndSecond_SwapedSuccessfully()
        {
            const string firstExpected = "first";
            string first = firstExpected;
            string second = "second";

            Swap(ref first, ref second);
            Assert.AreEqual<string>(
                firstExpected, second);
            Assert.AreEqual<string>(
                "second", first);
        }

        private void Swap(ref string first, ref string second)
        {
            string temp = first;
            first = second;
            second = temp;
        }



        [TestMethod]
        public void Rotate_Null_Success()
        {
            Rotate();
        }

        [TestMethod]
        public void Rotate_Empty_Success()
        {
            Rotate(new string[0]);
        }

        [TestMethod]
        public void Rotate_3parameters_Success()
        {
            string[] items = { "1", "2", "3", "0" };

            Rotate(items);

            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual<int>(
                    i, int.Parse(items[i]));
            }
        }
        
        [TestMethod]
        public void Rotate_OneItem_Success()
        {
            string first = "first";
            string[] items = new string[]{first};
            Rotate(items);
            Assert.AreSame(first, items[0]);
        }

        private void Rotate(params string[] items)
        {
            if (items == null || items.Length < 1)
            {
                return;
            }
            string temp = items[items.Length-1];
            for (int i = items.Length-1; i >0; i--)
            {
                items[i] = items[i-1];
            }
            items[0] = temp;
        }
    }


}
