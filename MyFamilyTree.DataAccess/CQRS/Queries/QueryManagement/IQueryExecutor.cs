

using Microsoft.IdentityModel.Tokens;

namespace MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
