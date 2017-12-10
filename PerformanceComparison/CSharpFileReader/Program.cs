using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CSharpFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Histogram>();
        }
    }

    [MemoryDiagnoser]
    public class Histogram
    {
        [Benchmark]
        public void PrintCharCount()
        {
            var path = @"..\..\RandomText.txt";
            Dictionary<char, int> charCount = new Dictionary<char, int>()
            {
                { 'A', 0},
                { 'B', 0},
                { 'C', 0},
                { 'D', 0},
                { 'E', 0},
                { 'F', 0},
                { 'G', 0},
                { 'H', 0},
                { 'I', 0},
                { 'J', 0},
                { 'K', 0},
                { 'L', 0},
                { 'M', 0},
                { 'N', 0},
                { 'O', 0},
                { 'P', 0},
                { 'Q', 0},
                { 'R', 0},
                { 'S', 0},
                { 'T', 0},
                { 'U', 0},
                { 'V', 0},
                { 'W', 0},
                { 'X', 0},
                { 'Y', 0},
                { 'Z', 0},
            };

            using (StreamReader fileContents = File.OpenText(path))
            {
                while (!fileContents.EndOfStream)
                {
                    char ch = Char.ToUpper((char)fileContents.Read());
                    if (!Char.IsLetter(ch))
                        continue;

                    if (charCount.ContainsKey(ch))
                    {
                        charCount[ch]++;
                    }
                }
            }

            //Commented out code can be commented in again to show the result of the file read in the console

            //foreach (var cCount in charCount)
            //{
            //    Console.WriteLine($"'{cCount.Key}': {cCount.Value} ");
            //}
        }
    }

}
