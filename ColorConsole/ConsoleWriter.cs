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

        }

        public void Write(string message, ConsoleColor foreGroundColor)
        {

        }

        public void Write(string message, ConsoleColor foreGroundColor, ConsoleColor backGroundColor)
        {

        }

        public void WriteLine(string message)
        {

        }

        public void WriteLine(string message, ConsoleColor foreGroundColor)
        {

        }

        public void WriteLine(string message, ConsoleColor foreGroundColor, ConsoleColor backGroundColor)
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
