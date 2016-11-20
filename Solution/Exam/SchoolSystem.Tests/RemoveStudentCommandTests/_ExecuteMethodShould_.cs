using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Tests.RemoveStudentCommandTests
{
   [TestFixture]
    public class _ExecuteMethodShould_
    {
        [Test]
        public void TryToRemoveStudent_WithThisId()
        {
            // Arrange
            var mockedEngine = new Mock<IEngine>();
            var command = new RemoveStudentCommand(mockedEngine.Object);

            mockedEngine.Setup(x => x.Students.Remove(It.IsAny<int>())).Verifiable();

            // Act
            var parameters = new string[] { "1" };
            command.Execute(parameters);

            // Assert
            mockedEngine.Verify(x => x.Students.Remove(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void ReturnCorrectMessage()
        {
            // Arrange
            var mockedEngine = new Mock<IEngine>();
            var command = new RemoveStudentCommand(mockedEngine.Object);
            mockedEngine.Setup(x => x.Students.Remove(It.IsAny<int>()));
            var parameters = new string[] { "1" };
            var expectedMessage = "Student with ID 1 was sucessfully removed.";

            // Act
            var message = command.Execute(parameters);

            // Asser
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
