﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MemoryGame
{
    class Game
    {
        List<string> Words;
        int NumberOfWords;
        int GuessChances;

        WordCard[] SelectedWords;

        public Game(List<string> words)
        {
            this.Words = words;
        }


        public void StartEasyGame()
        {
            NumberOfWords = 4;
            GuessChances = 10;
            
            GetGameWords();

        }

        public void StartHardGame()
        {
            NumberOfWords = 8;
            GuessChances = 15;

            GetGameWords();

        }


        private void GetGameWords()
        {
            SelectedWords = new WordCard[(NumberOfWords * 2)];

            Random random = new Random();
            WordCard tmp;


            for (int i = 0; i < (NumberOfWords * 2); i += 2)
            {
                int index = random.Next(Words.Count);
                tmp = new WordCard(Words[index],WordCardStatus.Hiden);

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
            Console.WriteLine();
        }


    }
}
