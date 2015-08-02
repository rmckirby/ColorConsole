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
        public void ConsoleColors_AreNotModified_OnWriteWithNoColors()
        {
            writer.Write("How can I help you?");
            console.VerifySet(c => c.ForegroundColor = It.IsAny<ConsoleColor>(), Times.Never);
            console.VerifySet(c => c.BackgroundColor = It.IsAny<ConsoleColor>(), Times.Never);
        }

        [Test]
        public void ConsoleWrite_IsInvoked_OnWriteWithForegroundColor()
        {
            string message = "What's going on here?";
            writer.Write(message, ConsoleColor.Blue);
            console.Verify(c => c.Write(message), Times.Once);
        }

        [Test]
        public void ConsoleForegroundColor_IsModified_OnWriteWithForegroundColor()
        {
            AssertForegroundColorIsModified(
                (color) => writer.Write("We'll have no trouble here!", color)
            );
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
            string message = "This is a local shop";
            writer.Write(message, ConsoleColor.Blue, ConsoleColor.Red);
            console.Verify(c => c.Write(message), Times.Once);
        }

        [Test]
        public void ConsoleColors_AreModified_OnWriteWithForegroundAndBackgroundColors()
        {
            AssertForegroundAndBackgroundColorsAreModified(
                (foreColor, backColor) => writer.Write("For local people", foreColor, backColor)
            );
        }

        [Test]
        public void ConsoleColors_AreRestored_AfterModificationOnWrite()
        {
            writer.Write("message", ConsoleColor.Yellow, ConsoleColor.Blue);

            Assert.AreEqual(ConsoleColor.White, console.Object.ForegroundColor);
            Assert.AreEqual(ConsoleColor.Black, console.Object.BackgroundColor);
        }

        [Test]
        public void ConsoleWriteLine_IsInvoked_OnWriteLine()
        {
            string message = "message";
            writer.WriteLine(message);
            console.Verify(c => c.WriteLine(message), Times.Once);
        }

        [Test]
        public void ConsoleColors_AreNotModified_OnWriteLineWithNoColors()
        {
            writer.WriteLine("hello");
            console.VerifySet(c => c.ForegroundColor = It.IsAny<ConsoleColor>(), Times.Never);
            console.VerifySet(c => c.BackgroundColor = It.IsAny<ConsoleColor>(), Times.Never);
        }

        [Test]
        public void ConsoleWriteLine_IsInvoked_OnWriteLineWithForegroundColor()
        {
            string message = "message";
            writer.WriteLine(message, ConsoleColor.DarkBlue);
            console.Verify(c => c.WriteLine(message), Times.Once);
        }

        private void AssertForegroundColorIsModified(Action<ConsoleColor> action)
        {
            var color = ConsoleColor.Cyan;
            action.Invoke(color);
            console.VerifySet(c => c.ForegroundColor = color, Times.Once);
        }

        private void AssertForegroundAndBackgroundColorsAreModified(
            Action<ConsoleColor, ConsoleColor> action)
        {
            var foreColor = ConsoleColor.Green;
            var backColor = ConsoleColor.Yellow;
            action(foreColor, backColor);

            console.VerifySet(c => c.ForegroundColor = foreColor, Times.Once);
            console.VerifySet(c => c.BackgroundColor = backColor, Times.Once);
        }
    }
}
