using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BronsonHolland_CE07
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("1. Datafile1\n"
                    + "2. Datafile2\n"
                    + "3. Datafile3\n"
                    + "4. Exit\n"
                    + "Please choose a file: ");
                string input = Console.ReadLine().ToLower();

                string headerFile = "DataFieldsLayout.txt";

                string[] headers = File.ReadAllLines(headerFile);

                switch (input)
                {
                    case "1":
                    case "datafile1":
                        {
                            ProcessFile("DataFile1.txt", "df1.json", headers);
                            Console.WriteLine("DataFile1 converted to JSON.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            Console.Clear();

                        }

                        break;
                    case "2":
                    case "datafile2":
                        {
                            ProcessFile("DataFile2.txt", "df2.json", headers);
                            Console.WriteLine("DataFile2 converted to JSON.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "3":
                    case "datafile3":
                        {
                            ProcessFile("DataFile3.txt", "df3.json", headers);
                            Console.WriteLine("DataFile3 converted to JSON.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "4":
                    case "exit":
                        {
                            return;
                        }
                }
            }
        }

        private static void ProcessFile(string textFile, string outputFile, string[] headers)
        {
            string[] rows = File.ReadAllLines(textFile);
            string[] newArray = rows.Skip(1).SkipLast(1).ToArray();

            List<List<Tuple<string, string>>> listOfRows = new List<List<Tuple<string, string>>>();

            foreach (var row in newArray)
            {
                List<Tuple<string, string>> tupleRow = new List<Tuple<string, string>>();

                string[] rowCells = row.Split('|');

                for (int i = 0; i < headers.Length; i++)
                {
                    Tuple<string, string> tuple = new Tuple<string, string>(headers[i], rowCells[i]);
                    tupleRow.Add(tuple);
                }
                listOfRows.Add(tupleRow);
            }

            StringBuilder text = new StringBuilder();
            text.AppendLine("[");
            foreach (List<Tuple<string, string>> row in listOfRows)
            {
                text.AppendLine("{");
                foreach (Tuple<string, string> headerCell in row)
                {
                    string header = headerCell.Item1;
                    string value = headerCell.Item2;
                    text.AppendLine($"\"{header}\":\"{value}\",");

                }
                text.Remove(text.ToString().LastIndexOf(','), 1);
                text.AppendLine("},");
            }
            text.Remove(text.ToString().LastIndexOf(','), 1);
            text.AppendLine("]");

            File.WriteAllText(outputFile, text.ToString());
        }
    }
}
