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

            console.SetupGet(c => c.ForegroundColor).Returns(ConsoleColor.White);
            console.SetupGet(c => c.BackgroundColor).Returns(ConsoleColor.Black);

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
        public void ConsoleColor_IsNotModified_OnOrdinaryWrite()
        {
            writer.Write("What's going on here?");
            console.VerifyGet(c => c.ForegroundColor, Times.Never);
            console.VerifyGet(c => c.BackgroundColor, Times.Never);
        }

        [Test]
        public void ConsoleWrite_IsInvoked_OnWriteWithForegroundColor()
        {
            string message = "How can I help you?";
            writer.Write(message, ConsoleColor.Blue);
            console.Verify(c => c.Write(message), Times.Once);
        }

        [Test]
        public void ConsoleForegroundColor_IsModified_OnWriteWithForegroundColor()
        {
            ConsoleColor color = ConsoleColor.Cyan;
            writer.Write("We'll have no trouble here!", color);
            console.VerifySet(c => c.ForegroundColor = color, Times.Once);
        }

        [Test]
        public void ConsoleForegroundColor_IsRestored_AfterModificationOnWrite()
        {
            writer.Write("I'll have you know", ConsoleColor.Yellow);
            Assert.AreEqual(ConsoleColor.White, console.Object.ForegroundColor);
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
