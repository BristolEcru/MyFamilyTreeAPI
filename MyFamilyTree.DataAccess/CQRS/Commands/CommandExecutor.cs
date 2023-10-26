using MyFamilyTree.DataAccess.CQRS.Queries;

namespace MyFamilyTree.DataAccess.CQRS.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly PeopleCollectionDbContext context;

        public CommandExecutor(PeopleCollectionDbContext context)
        {
            this.context = context;
        }
     
        public Task<TResult> ExecuteAsync<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.ExecuteAsync(this.context);
        }
    }
}