using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctWordsApp.Classes
{
    struct Word
    {
        readonly string value = "";
        private int count = 0;

        public Word(string word)
        {
            value = word;
        }

        public string Value()
        {
            return value;
        }

        public int Count()
        {
            return count;
        }

        public void SetCount(int number)
        {
            count = number;
        }
    }
}
