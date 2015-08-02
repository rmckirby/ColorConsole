using System;

namespace ColorConsole
{
    public interface IConsoleWriter
    {
        void Write(string message);
        void Write(string message, ConsoleColor foregroundColor);
        void Write(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor);
        
        void WriteLine(string message);
        void WriteLine(string message, ConsoleColor foregroundColor);
        void WriteLine(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor);

        void SetForeGroundColor(ConsoleColor color);
        void SetBackGroundColor(ConsoleColor color);
    }
}
