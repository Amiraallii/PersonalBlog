using MediatR;
using Personal.Domain.Contracts;

namespace Personal.Application.Features.Users.Command.EditUser
{
    public class EditUserCommandHandler(IUserRepository _userRepository, IUnitOfWork unitOfWork) : IRequestHandler<EditUserCommand>
    {
        public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
			try
			{
				var user = await _userRepository.GetUserByIdAsync(request.Id, cancellationToken);
				if (user is null)
				{
					throw new KeyNotFoundException("no user found");
				}
                if (await _userRepository.IsEmailOrUsernameTakenAsync(request.Id, request.Email, request.UserName, cancellationToken))
                {
                    throw new InvalidOperationException("these userName or email already is used by another user");

                }
                user.UpdateUserInfo(request.Email, request.UserName, request.FullName, user.RoleId);
				
                await _userRepository.UpdateUserAsync(user, cancellationToken);
				await unitOfWork.SaveChangesAsync();

			}
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
