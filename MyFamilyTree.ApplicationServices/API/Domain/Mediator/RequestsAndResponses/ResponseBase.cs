namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses
{
    public abstract class ResponseBase<T>
    {
        public T Data { get; set; }
    }
}