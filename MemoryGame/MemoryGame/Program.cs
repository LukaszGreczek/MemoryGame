using System;
using System.IO;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri uri = new Uri(Path.GetFullPath("Words.txt"));
            WordsReader wr = new WordsReader(uri);

            Game game = new Game(wr.Words);
            game.StartHardGame();
        }
    }
}
