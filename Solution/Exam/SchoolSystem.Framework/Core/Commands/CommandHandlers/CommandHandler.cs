using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands.CommandHandlers
{
    public abstract class CommandHandler : ICommandHandler
    {
        protected ICommandFactory commandFactory;

        public CommandHandler(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        protected ICommandHandler Successor { get; set; }

        protected abstract bool CanCreate(string commandName);

        public abstract ICommand CreateCommand(string commandName);

        public void SetSuccessor(ICommandHandler successor)
        {
            this.Successor = successor;
        }
    }
}
