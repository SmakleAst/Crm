using Identity.Domain.Entities;

namespace Identity.Application.Interfaces
{
    public interface IJwtToken
    {
        string Generate(User user);
    }
}
