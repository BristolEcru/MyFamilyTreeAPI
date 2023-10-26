

namespace MyFamilyTree.DataAccess.CQRS.Commands
{
    public interface ICommandExecutor
    {
        Task<TResult> 
            ExecuteAsync<TParameters, TResult>

                 (CommandBase<TParameters,TResult> command);
    }
}
