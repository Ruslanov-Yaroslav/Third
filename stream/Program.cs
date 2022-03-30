using System;
using System.Collections.Generic;

namespace stream
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToWritePath = $"C:\\Main\\output_23-02-2022.txt";
            List<int> f = new List<int>();
            Creator test = new Creator(f);

            test.CreateFilesForReading("txt");
            Console.WriteLine("Hello!!! I glad to see you");
            test.ReadFromTextFile();
            test.ShowAllElements(f);
            Console.WriteLine("Its was digitst from files)");
            Console.WriteLine($"Its Summary of this digits: {test.SumOfNumbers(f)}");
            Console.WriteLine($"Its Multiply of this digits: {test.MuliplyOfNumbers(f)}");
            Console.WriteLine($"Its Divide of this digits: {test.DivideFirstAndSecond(f)}");
            test.MathOperations(test, f);
            Console.WriteLine($"THX))) File in Path : {fileToWritePath}  was successfully written!))))");

            test.DeleteFilesFromPc();
        }
    }
}
