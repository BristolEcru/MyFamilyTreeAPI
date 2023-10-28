namespace MyFamilyTree.DataAccess.CQRS.Queries.QueryManagement
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(PeopleCollectionDbContext context);

    }
}
