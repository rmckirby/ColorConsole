using System;

namespace ColorConsole
{
    public interface IConsoleWriter
    {
        void Write(string message);
        void Write(string message, ConsoleColor foreground);
        void Write(string message, ConsoleColor foreground, ConsoleColor background);
        
        void WriteLine(string message);
        void WriteLine(string message, ConsoleColor foreground);
        void WriteLine(string message, ConsoleColor foreground, ConsoleColor background);

        void SetForeGroundColor(ConsoleColor color);
        void SetBackGroundColor(ConsoleColor color);
    }
}
