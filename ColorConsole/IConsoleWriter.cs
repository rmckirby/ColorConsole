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

        void SetForeGroundColor(ConsoleColor color);
        void SetBackGroundColor(ConsoleColor color);
    }
}
