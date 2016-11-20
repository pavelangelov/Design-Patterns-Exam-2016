using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private IEngine engine;

        public StudentListMarksCommand(IEngine engine)
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
            var student = this.engine.Students[studentId];
            return student.ListMarks();
        }
    }
}
