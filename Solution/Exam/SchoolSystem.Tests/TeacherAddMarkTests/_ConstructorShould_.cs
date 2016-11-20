using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using System;

namespace SchoolSystem.Tests.TeacherAddMarkTests
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfPassedEngineIsNull()
        {
            IEngine engine = null;

            var message = Assert.Throws<ArgumentNullException>(() => new TeacherAddMarkCommand(engine)).Message;

            Assert.IsTrue(message.Contains("engine"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            var mockedEngine = new Mock<IEngine>();

            var command = new TeacherAddMarkCommand(mockedEngine.Object);

            Assert.AreEqual(typeof(TeacherAddMarkCommand), command.GetType());
        }
    }
}
