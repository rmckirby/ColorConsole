using System;

namespace ColorConsole
{
    internal interface IConsoleWrapper
    {
        void Write(string message);
        void WriteLine(string message);

        ConsoleColor ForegroundColor { get; set; }
        ConsoleColor BackgroundColor { get; set; }
    }
}
