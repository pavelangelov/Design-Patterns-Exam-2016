using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Factories
{
    public interface IPersonFactory
    {
        IStudent GetStudent(string firstName, string lastName, Grade grade);

        ITeacher GetTeacher(string firstName, string lastName, Subject subject);
    }
}
