

using Microsoft.IdentityModel.Tokens;

namespace MyFamilyTree.DataAccess.CQRS.Queries
{
    public interface IQueryExecutor
    {
        Task<TResult> ExecuteAsync<TResult>(QueryBase<TResult> query);
    }
}
