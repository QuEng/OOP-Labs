using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stream {
    class Program {
        static void Main(string[] args) {
            SecondTask();
            Console.ReadLine();
        }

        static void FirstTask() {
            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader($"{filename}.txt", Encoding.Default)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    result.Add(line);
                }
            }
            result.Reverse();
            using (StreamWriter outputFile = new StreamWriter($"{filename}_reverse.txt")) {
                foreach (var line in result) {
                    outputFile.WriteLine(line);
                }
            }
            Console.WriteLine($"{filename}: Successful");
        }

        static void SecondTask() {
            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();
            StreamReader fileIn = new StreamReader($"{filename}.txt", Encoding.Default);
            StreamWriter fileOut = new StreamWriter($"{filename}_regex_output.txt");
            string text = fileIn.ReadToEnd();
            Regex r = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}\b");
            Match integer = r.Match(text);
            while (integer.Success) {
                fileOut.WriteLine(integer);
                integer = integer.NextMatch();
            }
            fileIn.Close();
            fileOut.Close();
            Console.WriteLine($"{filename}: Successful");
        }
    }
}
