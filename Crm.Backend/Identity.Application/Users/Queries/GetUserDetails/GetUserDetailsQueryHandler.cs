using AutoMapper;
using Identity.Application.Common.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IIdentityDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IIdentityDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.Id);

            return _mapper.Map<UserDetailsVm>(user);
        }
    }
}
