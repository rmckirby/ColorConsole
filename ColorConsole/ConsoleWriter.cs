using System;

namespace ColorConsole
{
    public sealed class ConsoleWriter
    {
        private readonly IConsoleWrapper console;

        public ConsoleWriter()
        {

        }

        internal ConsoleWriter(IConsoleWrapper console)
        {
            this.console = console;
        }
    }
}
