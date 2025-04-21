using MediatR;

namespace Identity.Application.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    { 
    }
}
