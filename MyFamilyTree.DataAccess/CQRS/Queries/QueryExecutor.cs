
namespace MyFamilyTree.DataAccess.CQRS.Queries
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly PeopleCollectionDbContext context;

        public QueryExecutor(PeopleCollectionDbContext context)
        {
            this.context = context;
        }
        public Task<TResult> ExecuteAsync<TResult>(QueryBase<TResult> query)
        {
            return query.ExecuteAsync(this.context);
        }
    }
}
