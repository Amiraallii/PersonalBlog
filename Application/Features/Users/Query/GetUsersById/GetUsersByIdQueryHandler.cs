using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;

namespace Personal.Application.Features.Users.Query.GetUsersById
{
    internal class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQuery, UsersDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersDto> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            return  new UsersDto
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                RoleId = user.RoleId,
                RoleName = user.Role.Name,
                UserName = user.UserName,
            };
        }
    }
}
