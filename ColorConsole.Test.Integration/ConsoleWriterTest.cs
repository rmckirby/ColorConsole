using ColorConsole;
using NUnit.Framework;
using Shouldly;
using System;
using System.IO;

namespace XogoEngine.Test.integration
{
    [TestFixture]
    internal sealed class ConsoleWriterTest
    {
        private ConsoleWriter consoleWriter;
        private StringWriter stringWriter;

        [SetUp]
        public void SetUp()
        {
            this.consoleWriter = new ConsoleWriter();
            this.stringWriter = new StringWriter();

            Console.SetOut(stringWriter);
        }
    }
}
