using MyFamilyTree.Domain.Entities;


namespace MyFamilyTree.ApplicationServices.Jwt
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
    }
}
