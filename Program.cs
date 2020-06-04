using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace patterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }


    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());
        }

        public static Journal Load(Journal j, string fileName)
        {
            throw new NotImplementedException();
        }

        public void Load(Journal j, Uri uri)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Oggi ho iniziato questo corso");
            j.AddEntry("Io amo gli animali");
            Console.WriteLine(j);

            var p = new Persistence();
            var fileName = @"journal.txt";
            p.SaveToFile(j, fileName);
        }
    }
}
