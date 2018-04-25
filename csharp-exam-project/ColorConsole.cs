using System;

namespace csharp_exam_project
{
    class ColorConsole
    {
        /// <summary>
        /// Clears error line(s) and one additional line before the error line(s) from Console.
        /// </summary>
        public static void ClearLine(int offset)
        {
            int currentCursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, currentCursorTop - offset);
            for (int i = 0; i < offset + 1; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, currentCursorTop - offset);
        }

        /// <summary>
        /// Clears the Console.
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints to Console.
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str)
        {
            Console.Write(str);
        }

        /// <summary>
        /// Prints to Console. Method uses the given ConsoleColor.
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints to Console with new line at the end
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLine(string str = "")
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Prints to Console with new line at the end. Method uses the given ConsoleColor.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints error to Console.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteError(string str, int offset = 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(str);

            Console.ReadKey();
            ClearLine(offset);

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints success to Console.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="vs"></param>
        public static void WriteSuccess(string str, params object[] vs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine(str);

            foreach (var item in vs)
            {
                Console.WriteLine(vs);
            }

            Console.WriteLine();
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}