using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello, My name is....");
            int result = 0;
            if (args != null && args.Length > 0) 
            {
                result = int.Parse(args[0]);
            }
            return result;

        }


#if IGNORE
        public static void DataTypeStuff()
        {
            Console.WriteLine("What is your name?");
            System.String text = "You killed my...";
            Console.WriteLine(text);
            string name = "Inigo Montoya"; // = Console.ReadLine();

            string greeting =
                string.Format("Hi {0}!  How are you?", name);
            Console.Write(greeting);

            bool isValid = true || false;

            isValid = true;

            if (isValid) { }

            Console.WriteLine(isValid);
            int number = (int)0xABC;
            42.ToString();
            number = int.Parse("42");

            Console.WriteLine(number);

            Int32 number32 = 73;
            Console.WriteLine(number32);

            text = "test";
            text = "text";

            text = "text" + text + text + text;
        }
#endif // DOTNET4
    }
}
