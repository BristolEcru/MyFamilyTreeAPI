

using MediatR;
using MyFamilyTree.ApplicationServices.Mediator.RequestsAndResponses.LoginUser;

namespace MyFamilyTree.ApplicationServices.Mediator.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        public Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
