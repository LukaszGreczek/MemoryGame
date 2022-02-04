using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemoryGame
{
    class WordsReader
    {
        List<string> Words = new List<string>();

        public WordsReader(Uri path)
        {
            
            this.ReadWordsFromFile(path);
        }

        private void ReadWordsFromFile(Uri path)
        {

            using (StreamReader streamReader = new StreamReader(path.AbsolutePath))
            {

                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    Words.Add(line);
                }

            }

        }

    }
}

