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
            ConsoleColor previous = console.ForegroundColor;
            SetForeGroundColor(foregroundColor);
            console.Write(message);
            SetForeGroundColor(previous);
        }

        public void Write(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            ConsoleColor previousForeColor = console.ForegroundColor;
            ConsoleColor previousBackColor = console.BackgroundColor;

            SetForeGroundColor(foregroundColor);
            SetBackGroundColor(backgroundColor);
            console.Write(message);
            SetForeGroundColor(previousForeColor);
            SetBackGroundColor(previousBackColor);
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
            console.ForegroundColor = color;
        }

        public void SetBackGroundColor(ConsoleColor color)
        {
            console.BackgroundColor = color;
        }
    }
}
