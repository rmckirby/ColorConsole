using Moq;
using NUnit.Framework;

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
            string message = "oh hai!";
            writer.Write(message);
            console.Verify(c => c.Write(message), Times.Once);
        }
    }
}
