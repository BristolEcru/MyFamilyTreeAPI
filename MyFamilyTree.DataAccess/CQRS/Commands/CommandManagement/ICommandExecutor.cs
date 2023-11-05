namespace MyFamilyTree.Domain.CQRS.Commands.CommandManagement
{
    public interface ICommandExecutor
    {
        Task<TResult>Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
