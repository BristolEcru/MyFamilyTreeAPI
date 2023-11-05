

namespace MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.Bases
{
   public class ErrorModel
    {
        public string Error { get;  }
        public ErrorModel(string error) {
            Error = error;
        }
    }
}
