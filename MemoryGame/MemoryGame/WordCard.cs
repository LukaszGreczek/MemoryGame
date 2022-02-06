using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGame
{
    class WordCard
    {
        public WordCard(string word,WordCardStatus wordCardStatus)
        {
            this.Word = word;
            this.CardStatus = wordCardStatus;
        }

        public string Word
        {
            get; set;
        }

        public WordCardStatus CardStatus
        {
            get; set;
        }

        public string DisplayWord()
        {
            if(CardStatus == WordCardStatus.Hiden)
            return "X";
            else
            {
                return Word;
            }
        }
    }
}
