﻿using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands.CommandHandlers
{
    public class TeacherAddMarkCommandHandler : CommandHandler
    {
        public TeacherAddMarkCommandHandler(ICommandFactory commandFactory) 
            : base(commandFactory)
        {
        }

        public override ICommand CreateCommand(string commandName)
        {
            if (this.CanCreate(commandName))
            {
                return this.commandFactory.GetTeacherAddMarkCommand();
            }

            if (this.Successor != null)
            {
                return this.Successor.CreateCommand(commandName);
            }
            else
            {
                return null;
            }
        }

        protected override bool CanCreate(string commandName)
        {
            return commandName == "TeacherAddMark";
        }
    }
}
