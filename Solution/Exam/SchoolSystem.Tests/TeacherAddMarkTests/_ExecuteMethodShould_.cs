using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.TeacherAddMarkTests
{
    [TestFixture]
    public class _ExecuteMethodShould_
    {
        [Test]
        public void CallTeacherAddMarkMethod()
        {
            // Arrange
            var mockedEngine = new Mock<IEngine>();
            var mockedStudent = new Mock<IStudent>();
            var mockedTeacher = new Mock<ITeacher>();
            var fakeStudents = new Dictionary<int, IStudent>();
            var fakeTeachers = new Dictionary<int, ITeacher>();
            var command = new TeacherAddMarkCommand(mockedEngine.Object);
            var parameters = new string[] { "1", "1", "3.5" };

            fakeStudents.Add(1, mockedStudent.Object);
            fakeTeachers.Add(1, mockedTeacher.Object);

            mockedEngine.Setup(x => x.Students).Returns(fakeStudents);
            mockedEngine.Setup(x => x.Teachers).Returns(fakeTeachers);

            mockedTeacher.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>())).Verifiable();

            // Act
            command.Execute(parameters);

            // Assert
            mockedTeacher.Verify(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()), Times.Once);
        }
    }
}
