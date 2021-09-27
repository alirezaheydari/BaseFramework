using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework
{
    public static class Word
    {
        public static string GetWord(params eAlphabet[] alphabets)
        {
            string Result = string.Empty;
            foreach (eAlphabet alphabet in alphabets)
            {
                Result += alphabet.ToString();
            }
            return Result;
        }
    }
}
