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
        int NumberOfWords;
        int GuessChances;
        int ArrayIndex;

        WordCard[] SelectedWords; // I must overide Equals method

        public Game(List<string> words)
        {
            this.Words = words;
        }


        public void StartEasyGame()
        {
            NumberOfWords = 4;
            GuessChances = 10;

            GetGameWords();
            Guess();

        }

        public void StartHardGame()
        {
            NumberOfWords = 8;
            GuessChances = 15;

            GetGameWords();
            Guess();
        }

        public void Guess()
        {
            for(; GuessChances > 0; GuessChances--)
            {
                Console.WriteLine("Select first word(Example: A1):");
                string line = "A1";
                string line2 = "B1";


                
                if (GetArrayIndex(line) == true)
                {
                    SelectedWords[ArrayIndex].CardStatus = WordCardStatus.Unveiled;
                    
                }
                WordCard tmp = SelectedWords[ArrayIndex];
                DisplayGame();

                Console.WriteLine("Select second word(Example: A1):");

                if (GetArrayIndex(line2) == true)
                {
                    SelectedWords[ArrayIndex].CardStatus = WordCardStatus.Unveiled;
                    
                }
                WordCard tmp2 = SelectedWords[ArrayIndex];
                DisplayGame();

                if(tmp == tmp2)
                {
                    tmp.CardStatus = WordCardStatus.Guessed;
                    tmp2.CardStatus = WordCardStatus.Guessed;
                }
                else
                {
                    tmp.CardStatus = WordCardStatus.Hiden;
                    tmp2.CardStatus = WordCardStatus.Hiden;
                }
            }
        }


        private void GetGameWords()
        {
            SelectedWords = new WordCard[(NumberOfWords * 2)];

            Random random = new Random();
            WordCard tmp;


            for (int i = 0; i < (NumberOfWords * 2); i += 2)
            {
                int index = random.Next(Words.Count);
                tmp = new WordCard(Words[index], WordCardStatus.Hiden);

                if (Array.Exists(SelectedWords, word => word == tmp)) 
                {
                    i -= 2;
                }
                else
                {
                    SelectedWords[i] = new WordCard(Words[index], WordCardStatus.Hiden);
                    SelectedWords[i + 1] = new WordCard(Words[index], WordCardStatus.Hiden);

                }

            }

            SelectedWords = SelectedWords.OrderBy(x => random.Next()).ToArray();
        }

        private void DisplayGame()
        {
            if (NumberOfWords == 4)
            {
                Console.WriteLine("Level: easy");
            }
            else
            {
                Console.WriteLine("Level: hard");
            }

            Console.WriteLine($"Guess chances: {GuessChances}");

            Console.WriteLine("    1   2   3   4");

            for (int i = 0; i < NumberOfWords * 2; i+=4)
            {
                Console.WriteLine($"{(char)(65 + i)}   {SelectedWords[i].DisplayWord()}   {SelectedWords[i + 1].DisplayWord()}   {SelectedWords[i + 2].DisplayWord()}   {SelectedWords[i + 3].DisplayWord()}");
            }
              
        }

        private bool GetArrayIndex(string coordinates) 
        {
            
            coordinates = coordinates.ToUpper();

            switch (coordinates)
            {
                case "A1":
                    ArrayIndex = 0;
                    return true;

                case "A2":
                    ArrayIndex = 1;
                    return true;

                case "A3":
                    ArrayIndex = 2;
                    return true;

                case "A4":
                    ArrayIndex = 3;
                    return true;

                case "B1":
                    ArrayIndex = 4;
                    return true;

                case "B2":
                    ArrayIndex = 5;
                    return true;

                case "B3":
                    ArrayIndex = 6;
                    return true;

                case "B4":
                    ArrayIndex = 7;
                    return true;
            }

            if (NumberOfWords == 8)
            {
                switch (coordinates)
                {
                    case "C1":
                        ArrayIndex = 8;
                        return true;

                    case "C2":
                        ArrayIndex = 9;
                        return true;

                    case "C3":
                        ArrayIndex = 10;
                        return true;

                    case "C4":
                        ArrayIndex = 11;
                        return true;

                    case "D1":
                        ArrayIndex = 12;
                        return true;

                    case "D2":
                        ArrayIndex = 13;
                        return true;

                    case "D3":
                        ArrayIndex = 14;
                        return true;

                    case "D4":
                        ArrayIndex = 15;
                        return true;

                    default:
                        return false;
                }

            }
            else
            {
                return false;
            }
        }

    }
}
