using System;

namespace ColorConsole
{
    public sealed class ConsoleWriter : IConsoleWriter
    {
        private readonly IConsoleWrapper console;

        public ConsoleWriter()
        {

        }

        internal ConsoleWriter(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Write(string message)
        {
            console.Write(message);
        }

        public void Write(string message, ConsoleColor foregroundColor)
        {

        }

        public void Write(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {

        }

        public void WriteLine(string message)
        {

        }

        public void WriteLine(string message, ConsoleColor foregroundColor)
        {

        }

        public void WriteLine(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {

        }

        public void SetForeGroundColor(ConsoleColor color)
        {

        }

        public void SetBackGroundColor(ConsoleColor color)
        {

        }
    }
}
