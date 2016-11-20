using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands.CommandHandlers
{
    public class StudentListMarksCommandHandler : CommandHandler
    {
        public StudentListMarksCommandHandler(ICommandFactory commandFactory)
            : base(commandFactory)
        {
        }

        public override ICommand CreateCommand(string commandName)
        {
            if (this.CanCreate(commandName))
            {
                return this.commandFactory.GetStudentListMarksCommand();
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
            return commandName == "StudentListMarks";
        }
    }
}
