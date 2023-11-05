using MyFamilyTree.Domain.CQRS.Queries;

namespace MyFamilyTree.Domain.CQRS.Commands.CommandManagement
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly PeopleCollectionDbContext context;

        public CommandExecutor(PeopleCollectionDbContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(context);
        }
    }
}