using MediatR;
using Personal.Domain.Contracts;


namespace Personal.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<DeleteUserCommand>
    {

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserByIdAsync(request.UserId, cancellationToken);
        }

    }
}
