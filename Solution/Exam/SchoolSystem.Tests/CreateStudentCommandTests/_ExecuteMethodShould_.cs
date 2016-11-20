using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.CreateStudentCommandTests
{
    [TestFixture]
    public class _ExecuteMethodShould_
    {
        [Test]
        public void CallGetStudentsMethod_FromPersonFactory()
        {
            // Arrange
            var fakeStudents = new Dictionary<int, IStudent>();
            var mockedEngine = new Mock<IEngine>();
            var mockedPersonFactory = new Mock<IPersonFactory>();

            mockedPersonFactory.Setup(x => x.GetStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Verifiable();
            mockedEngine.Setup(x => x.Students.Count).Returns(0);
            mockedEngine.Setup(x => x.Students).Returns(fakeStudents);

            // Act
            var command = new CreateStudentCommand(mockedEngine.Object, mockedPersonFactory.Object);
            var parameters = new string[] { "Pesho", "Peshev", "3" };
            command.Execute(parameters);

            // Assert
            mockedPersonFactory.Verify(x => x.GetStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()), Times.Once);
        }

        [Test]
        public void AddStudentToEngine()
        {
            // Arrange
            var fakeStudents = new Dictionary<int, IStudent>();
            var mockedStudent = new Mock<IStudent>();
            var mockedEngine = new Mock<IEngine>();
            var mockedPersonFactory = new Mock<IPersonFactory>();

            mockedPersonFactory.Setup(x => x.GetStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(mockedStudent.Object);
            mockedEngine.Setup(x => x.Students).Returns(fakeStudents);

            // Act
            var command = new CreateStudentCommand(mockedEngine.Object, mockedPersonFactory.Object);
            var parameters = new string[] { "Pesho", "Peshev", "3" };
            command.Execute(parameters);

            // Assert
            Assert.IsTrue(fakeStudents.Count == 1);
            Assert.IsTrue(fakeStudents.ContainsValue(mockedStudent.Object));
        }
    }
}
