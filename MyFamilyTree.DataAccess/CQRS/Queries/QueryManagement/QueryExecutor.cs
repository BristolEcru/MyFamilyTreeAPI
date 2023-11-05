namespace MyFamilyTree.Domain.CQRS.Queries.QueryManagement
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly PeopleCollectionDbContext context;

        public QueryExecutor(PeopleCollectionDbContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(context);
        }
    }
}
