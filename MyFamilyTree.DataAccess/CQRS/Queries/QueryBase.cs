

namespace MyFamilyTree.DataAccess.CQRS.Queries
{
    public abstract class QueryBase <TResult>
    {
        public abstract Task<TResult> ExecuteAsync(PeopleCollectionDbContext context);

    }
}
