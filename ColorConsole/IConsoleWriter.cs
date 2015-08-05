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

        [Obsolete("To be removed in the next major release.")]
        void Write(string message);
        [Obsolete("To be removed in the next major release.")]
        void Write(string message, ConsoleColor foreground);
        [Obsolete("To be removed in the next major release.")]
        void Write(string message, ConsoleColor foreground, ConsoleColor background);

        [Obsolete("To be removed in the next major release.")]
        void WriteLine(string message);
        [Obsolete("To be removed in the next major release.")]
        void WriteLine(string message, ConsoleColor foreground);
        [Obsolete("To be removed in the next major release.")]
        void WriteLine(string message, ConsoleColor foreground, ConsoleColor background);

        void SetForeGroundColor(ConsoleColor color);
        void SetBackGroundColor(ConsoleColor color);
    }
}
