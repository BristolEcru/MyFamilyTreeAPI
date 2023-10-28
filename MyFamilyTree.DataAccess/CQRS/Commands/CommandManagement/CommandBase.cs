namespace MyFamilyTree.DataAccess.CQRS.Commands.CommandManagement
{
    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter { get; set; }

        public abstract Task<TResult> Execute(PeopleCollectionDbContext context);
    }
}
