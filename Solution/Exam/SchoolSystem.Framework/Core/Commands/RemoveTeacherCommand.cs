using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private IEngine engine;

        public RemoveTeacherCommand(IEngine engine)
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

            if (!this.engine.Teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.engine.Teachers.Remove(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
