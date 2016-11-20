using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands.CommandHandlers
{
    public class CreateStudentCommandHandler : CommandHandler
    {
        public CreateStudentCommandHandler(ICommandFactory commandFactory)
            : base(commandFactory)
        {
        }

        protected override bool CanCreate(string commandName)
        {
            return commandName == "CreateStudent";
        }

        public override ICommand CreateCommand(string commandName)
        {
            if (this.CanCreate(commandName))
            {
                var command = this.commandFactory.GetCreateStudentCommand();
                return command;
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
    }
}
