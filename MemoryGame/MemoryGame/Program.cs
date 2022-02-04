using System;
using System.IO;
namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri(Path.GetFullPath("Words.txt"));
            WordsReader wr = new WordsReader(uri);


        }
    }
}
