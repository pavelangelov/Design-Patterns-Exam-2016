using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private IEngine engine;
        private IPersonFactory personFactory;

        public CreateTeacherCommand(IEngine engine, IPersonFactory personFactory)
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
            var subject = (Subject)int.Parse(parameters[2]);
            var currentTeacherId = this.engine.Teachers.Count;

            var teacher = this.personFactory.GetTeacher(firstName, lastName, subject);
            this.engine.Teachers.Add(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId} was created.";
        }
    }
}
