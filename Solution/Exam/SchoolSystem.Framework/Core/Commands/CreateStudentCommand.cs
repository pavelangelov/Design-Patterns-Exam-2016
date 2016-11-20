using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private IEngine engine;
        private IPersonFactory personFactory;

        public CreateStudentCommand(IEngine engine, IPersonFactory personFactory)
        {
            if (engine == null)
            {
                throw new ArgumentNullException("engine");
            }

            this.engine = engine;

            if (personFactory == null)
            {
                throw new ArgumentNullException("personFactory");
            }

            this.personFactory = personFactory;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var currentStudentId = this.engine.Students.Count;

            var student = this.personFactory.GetStudent(firstName, lastName, grade);
            this.engine.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId} was created.";
        }
    }
}
