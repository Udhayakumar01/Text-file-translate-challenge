using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizedTranslate
{
    public static class Program
    {
        public static int OccurencesOf(this string str, string val)
        {
            int num_occurrences = 0;
            int num_startingIndex = 0;

            while ((num_startingIndex = str.IndexOf(val, num_startingIndex)) >= 0)
            {
                ++num_occurrences;
                ++num_startingIndex;
            }

            return num_occurrences;
        }
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Dictionary<string, string> csvDictionary = new Dictionary<string, string>();
            csvDictionary.Add("English Word" , "French Word, Frequency");
            using (var CsvReader = new StreamReader("french_dictionary.csv"))
            {
                while (!CsvReader.EndOfStream)
                {
                    var line = CsvReader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    dictionary.Add(values[0], values[1]);
                }
            }
            string Text = File.ReadAllText("t8.shakespeare.translated.txt");
            StringBuilder sb = new StringBuilder(Text);
            string filePath = @"frequency.csv";
            string key;
            int count = 0;
            foreach(KeyValuePair<string,string> item in dictionary)
            {
               key = item.Key;
               Text.IndexOf(key);
                count = OccurencesOf(Text,key);
                csvDictionary.Add(key,  item.Value+" , "+count );
               
            }
            String csv = String.Join(
            Environment.NewLine,
            csvDictionary.Select(d => $"{d.Key} , {d.Value}"));
            System.IO.File.WriteAllText(filePath, csv);
            foreach (var item in dictionary)
            {
                sb.Replace(item.Key,item.Value);
                //Console.WriteLine(count);
            }
            Text = sb.ToString();
            File.WriteAllText("t8.shakespeare.translated.txt", Text);
            Console.ReadKey();
        }
    }
    
    
}
