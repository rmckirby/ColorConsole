using System;

namespace ColorConsole
{
    public interface IConsoleWriter
    {
        void Write(string message);
        void Write(string message, ConsoleColor foreGroundColor);
        void Write(string message, ConsoleColor foreGroundColor, ConsoleColor backGroundColor);
        
        void WriteLine(string message);
        void WriteLine(string message, ConsoleColor foreGroundColor);
        void WriteLine(string message, ConsoleColor foreGroundColor, ConsoleColor backGroundColor);

        void SetForeGroundColor(ConsoleColor color);
        void SetBackGroundColor(ConsoleColor color);
    }
}
