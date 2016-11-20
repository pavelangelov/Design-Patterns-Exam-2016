using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CommandHandlers
{
    public interface ICommandHandler
    {
        ICommand CreateCommand( string commandName);

        void SetSuccessor(ICommandHandler successor);
    }
}
