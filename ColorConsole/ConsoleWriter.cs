using System;

namespace ColorConsole
{
    public sealed class ConsoleWriter : IConsoleWriter
    {
        private readonly IConsoleWrapper console;

        public ConsoleWriter()
            : this(new ConsoleWrapper())
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

        public void Write(string message, ConsoleColor foreground)
        {
            WriteWithForegroundColor(() => Write(message), foreground);
        }

        public void Write(string message, ConsoleColor foreground, ConsoleColor background)
        {
            WriteWithForegroundAndBackgroundColors(
                () => Write(message),
                foreground,
                background
            );
        }

        public void WriteLine(string message)
        {
            console.WriteLine(message);
        }

        public void WriteLine(string message, ConsoleColor foreground)
        {
            WriteWithForegroundColor(() => WriteLine(message), foreground);
        }

        public void WriteLine(string message, ConsoleColor foreground, ConsoleColor background)
        {
            WriteWithForegroundAndBackgroundColors(
                () => WriteLine(message),
                foreground,
                background
            );
        }

        public void SetForeGroundColor(ConsoleColor color)
        {
            console.ForegroundColor = color;
        }

        public void SetBackGroundColor(ConsoleColor color)
        {
            console.BackgroundColor = color;
        }

        private void WriteWithForegroundColor(Action write, ConsoleColor color)
        {
            ConsoleColor previous = console.ForegroundColor;
            SetForeGroundColor(color);
            write();
            SetForeGroundColor(previous);
        }

        private void WriteWithForegroundAndBackgroundColors(
            Action write,
            ConsoleColor foreground,
            ConsoleColor background)
        {
            ConsoleColor previousForeground = console.ForegroundColor;
            ConsoleColor previousBackground = console.BackgroundColor;

            SetForeGroundColor(foreground);
            SetBackGroundColor(background);
            write();
            SetForeGroundColor(previousForeground);
            SetBackGroundColor(previousBackground);
        }
    }
}
