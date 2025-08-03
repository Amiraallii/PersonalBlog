using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;

namespace Personal.Application.Features.Users.Query.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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
