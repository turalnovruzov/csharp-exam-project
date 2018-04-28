using System;

namespace csharp_exam_project
{
    class View
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
        /// Prints to Console and waits for the user to press any key.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteAndWait(string str)
        {
            Console.Write(str);
            Console.ReadKey(true);
        }

        /// <summary>
        /// Prints to Console and waits for the user to press any key. Method uses the given ConsoleColor.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteAndWait(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
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
        /// Prints to Console with new line at the end and waits for the user to press any key.
        /// </summary>
        public static void WriteLineAndWait(string str)
        {
            Console.WriteLine(str);
            Console.ReadKey(true);
        }

        /// <summary>
        /// Prints to Console with new line at the end and waits for the user to press any key. Method uses the given ConsoleColor.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLineAndWait(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
        }

        /// <summary>
        /// Prints error to Console and waits for User to read and press any key.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteError(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(str);

            Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints error to Console and waits for User to read and press any key, then clears the Console.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteErrorAndClear(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(str);

            Console.ReadKey(true);
            Clear();

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints success to Console and waits for user to press any key.
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
            Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}