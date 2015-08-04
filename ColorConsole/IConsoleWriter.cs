using System;

namespace ColorConsole
{
    public interface IConsoleWriter
    {
        void Write<T>(T message);
        void Write<T>(T message, ConsoleColor foreground);
        void Write<T>(T message, ConsoleColor foreground, ConsoleColor background);

        void WriteLine<T>(T message);
        void WriteLine<T>(T message, ConsoleColor foreground);
        void WriteLine<T>(T message, ConsoleColor foreground, ConsoleColor background);

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
