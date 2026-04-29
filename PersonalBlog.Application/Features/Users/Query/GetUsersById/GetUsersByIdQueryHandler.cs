using MediatR;
using PersonalBlog.Application.Dtos;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Users.Query.GetUsersById
{
    internal class GetUsersByIdQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetUsersByIdQuery, UsersDto>
    {

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
