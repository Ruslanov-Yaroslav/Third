using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace stream
{
    class Creator
    {
        string directoryPath = "C:\\Main\\1";
        string fileToWritePath = $"C:\\Main\\output_23-02-2022.txt";
        public List<int> intFromTextFile;
        char forTxt = ' ';
        char forCsv = ',';
        char usingChar;

        public Creator(List<int> intFrom)
        {
            this.intFromTextFile = intFrom;
        }

        public IEnumerable<int> ReadFromTextFile()
        {
            try
            {
                var directoryPathList = GetPathFromDirectory(directoryPath);
                foreach(var a in directoryPathList)
                {
                    StreamReader sr = new StreamReader(a);
                    var line = sr.ReadToEnd();
                    var splitedList = a.Contains(".txt") ? line.Split(' ') : line.Split(',');
                    
                    foreach (var x in splitedList)
                    {
                        var toInt = Int32.Parse(x);
                        intFromTextFile.Add(toInt);
                    }
                    sr.Close();
                    }    
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return intFromTextFile;
        }

        public int SumOfNumbers(List<int> a)
        {
            return a.Sum();
        }

        public int MuliplyOfNumbers(List<int> a)
        {
           var temp = 1;
           foreach(var x in a)
           {
                temp = temp * x;
           }
           return temp;
        }

        public int  DivideFirstAndSecond(List<int> a)
        {
            var temp = 1;
            try
            {
                foreach (var x in a)
                {
                    temp = x / temp;
                }
                return temp;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }

        public List<string> GetPathFromDirectory(string directiryPathTmp)
        {
            List<string> res = Directory.GetFiles(directiryPathTmp).ToList();
            return res;
        }

        public void ShowAllElements(List<int> f)
        {
            foreach (var x in f)
            {
                Console.WriteLine(x);
            }
        }

        public void MathOperations(Creator test , List<int> f)
        {
            usingChar = fileToWritePath.Contains("txt") ? forTxt : forCsv;
           
            try
            {
                FileStream fstream = new FileStream(fileToWritePath, FileMode.OpenOrCreate);
                fstream.Close();
                using (StreamWriter writer = new StreamWriter(fileToWritePath, true))
                {
                    writer.WriteLine($"{f[0]}{usingChar}{f[1]}{usingChar}{test.SumOfNumbers(f)}{usingChar}" +
                        $"{test.MuliplyOfNumbers(f)}{usingChar}{test.DivideFirstAndSecond(f)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void CreateFilesForReading(string fileType)
        {
            Directory.CreateDirectory(directoryPath);

            usingChar = fileType.Contains("txt") ? forTxt : forCsv;
           
            for(int i = 0; i < 3; i++)
            {
                string temp = $"C:\\Main\\1\\{i}.{fileType}";
                FileStream fstream = new FileStream(temp, FileMode.OpenOrCreate);

                fstream.Close();
                using (StreamWriter writer = new StreamWriter(temp, true))
                {
                    writer.WriteLine($"1{usingChar}2");
                }
            }
        }

        public void DeleteFilesFromPc()
        {
            Directory.Delete(directoryPath , Directory.Exists(directoryPath)) ;
        }
    }
}

