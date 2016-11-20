using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using System;

namespace SchoolSystem.Tests.CreateStudentCommandTests
{
    [TestFixture]
    public class _ConstructorShould_
    {
        [Test]
        public void ThrowArgumentNullException_IfPassedEngineIsNull()
        {
            IEngine engine = null;
            var mockedPersonFactory = new Mock<IPersonFactory>();

            var message = Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(engine, mockedPersonFactory.Object)).Message;

            Assert.IsTrue(message.Contains("engine"));
        }

        [Test]
        public void ThrowArgumentNullException_IfPassedPersonFactoryIsNull()
        {
            var mockedEngine = new Mock<IEngine>();
            IPersonFactory personFactory = null;

            var message = Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(mockedEngine.Object, personFactory)).Message;

            Assert.IsTrue(message.Contains("personFactory"));
        }

        [Test]
        public void NotToThrow_IfPassedParametersAreValid()
        {
            var mockedEngine = new Mock<IEngine>();
            var mockedPersonFactory = new Mock<IPersonFactory>();

            var command = new CreateStudentCommand(mockedEngine.Object, mockedPersonFactory.Object);

            Assert.AreEqual(typeof(CreateStudentCommand), command.GetType());
        }
    }
}
