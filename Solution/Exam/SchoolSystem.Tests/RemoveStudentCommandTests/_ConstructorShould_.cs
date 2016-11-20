using System;

using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Tests.RemoveStudentCommandTests
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfPassedEngineIsNull()
        {
            var message = Assert.Throws<ArgumentNullException>(() => new RemoveStudentCommand(null)).Message;

            Assert.IsTrue(message.Contains("engine"));
        }

        [Test]
        public void NotToThrow_IfPassedParameterIsValid()
        {
            var mockedEngine = new Mock<IEngine>();

            var command = new RemoveStudentCommand(mockedEngine.Object);

            Assert.AreEqual(typeof(RemoveStudentCommand), command.GetType());
        }
    }
}
