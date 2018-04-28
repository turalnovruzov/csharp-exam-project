using System;

namespace csharp_exam_project
{
    /// <summary>
    /// Random pin generator
    /// </summary>
    static class PinGenerator
    {
        private static string letters;
        private static string digits;
        private static Random random;

        /// <summary>
        /// Generates a random pin with length of 4
        /// </summary>
        /// <returns>The random generated pin</returns>
        public static string NewPin()
        {
            char[] pin = new char[4];

            int nLetters = random.Next(1, 4);
            int nDigits = 4 - nLetters;

            int i = 0;
            while (nLetters > 0 && nDigits > 0)
            {
                if (random.Next(0,2) == 0)
                {
                    pin[i] = letters[random.Next(0, letters.Length)];
                    nLetters--;
                }
                else
                {
                    pin[i] = digits[random.Next(0, digits.Length)];
                    nDigits--;
                }
                i++;
            }

            if (nLetters > 0)
            {
                while (nLetters > 0)
                {
                    pin[i++] = letters[random.Next(0, letters.Length)];
                    nLetters--;
                }
            }
            else
            {
                while (nDigits > 0)
                {
                    pin[i++] = digits[random.Next(0, digits.Length)];
                    nDigits--;
                }
            }

            return new string(pin);
        }

        static PinGenerator()
        {
            letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            digits = "0123456789";
            random = new Random();
        }
    }
}
