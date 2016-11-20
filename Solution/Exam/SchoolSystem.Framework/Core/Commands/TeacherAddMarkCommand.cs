using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private IEngine engine;

        public TeacherAddMarkCommand(IEngine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException("engine");
            }

            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.engine.Students[studentId];
            var teacher = this.engine.Teachers[teacherId];

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
