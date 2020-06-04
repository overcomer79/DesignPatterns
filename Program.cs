using System;
using System.Collections.Generic;
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

        public void Save(string fileName)
        {
            File.WriteAllText(fileName, ToString());
        }

        public static Journal Load(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Load(Uri uri)
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
        }
    }
}
