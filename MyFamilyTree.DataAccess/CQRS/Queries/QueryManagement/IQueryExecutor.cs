

using Microsoft.IdentityModel.Tokens;

namespace MyFamilyTree.Domain.CQRS.Queries.QueryManagement
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
