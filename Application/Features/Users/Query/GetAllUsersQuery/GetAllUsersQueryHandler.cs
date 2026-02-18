using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;

namespace Personal.Application.Features.Users.Query.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetAllUsersQuery, List<UsersDto>>
    {

        public async Task<List<UsersDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
        {
            var userList = await _userRepository.GetAllUsers(ct);

            return  userList.Select(x=> new UsersDto
            {
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id,
                RoleId = x.RoleId,
                RoleName = x.Role.Name,
                UserName = x.UserName,
            }).ToList();


        }
    }
}
