

using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases;

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases
{
    public abstract class ErrorResponseBase  
    {
        public ErrorModel Error { get; set; }
    }
}
