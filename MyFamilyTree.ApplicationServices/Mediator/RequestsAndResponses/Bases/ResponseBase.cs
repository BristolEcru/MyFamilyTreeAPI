using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.BaseClasses
{
    public abstract class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; }
    }
}