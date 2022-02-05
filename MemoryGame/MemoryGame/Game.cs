using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MemoryGame
{
    class Game
    {
        List<string> Words;

        string[] SelectedWords = new string[16];

        public Game(List<string> words)
        {
            this.Words = words;
        }


        public void GetGameWords(int NumberOfWords)
        {
            Random random = new Random();
            string tmp;

            for (int i = 0; i < (NumberOfWords * 2); i += 2)
            {
                int index = random.Next(Words.Count);
                tmp = Words[index];

                if (Array.Exists(SelectedWords, word => word == tmp))
                {
                    i -= 2;
                }
                else
                {
                    SelectedWords[i] = tmp;
                    SelectedWords[i + 1] = tmp;

                }

            }

            SelectedWords = SelectedWords.OrderBy(x => random.Next()).ToArray();
            
        }


    }
}
