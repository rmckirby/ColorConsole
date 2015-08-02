using Moq;
using NUnit.Framework;
using System;

namespace ColorConsole.Test
{
    [TestFixture]
    internal sealed class ConsoleWriterTest
    {
        private Mock<IConsoleWrapper> console;
        private ConsoleWriter writer;

        [SetUp]
        public void SetUp()
        {
            console = new Mock<IConsoleWrapper>();
            writer = new ConsoleWriter(console.Object);
        }

        [Test]
        public void ConsoleWrite_IsInvoked_OnWriteWithNoColors()
        {
            string message = "hello...";
            writer.Write(message);
            console.Verify(c => c.Write(message), Times.Once);
        }

        [Test]
        public void ConsoleWrite_IsInvoked_OnWriteWithForegroundColor()
        {
            string message = "How can I help you?";
            writer.Write(message, ConsoleColor.Blue);
            console.Verify(c => c.Write(message), Times.Once);
        }

        [Test]
        public void ConsoleWrite_IsInvoked_OnWriteWithForegroundAndBackgroundColors()
        {
            string message = "Well, well...";
            writer.Write(message, ConsoleColor.Blue, ConsoleColor.Red);
            console.Verify(c => c.Write(message), Times.Once);
        }
    }
}
