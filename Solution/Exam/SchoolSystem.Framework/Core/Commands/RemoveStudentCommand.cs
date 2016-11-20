using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private IEngine engine;

        public RemoveStudentCommand(IEngine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException("engine");
            }

            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            this.engine.Students.Remove(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
