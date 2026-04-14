using MediatR;
using Personal.Domain.Contracts;

namespace PersonalBlog.Application.Features.Authentication.Commands.Logout
{
    public class LogoutHandler(IUnitOfWork unitOfWork) : IRequestHandler<LogoutCommand>
    {
        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(request.Id, cancellationToken);

            if(user == null) 
                throw new NullReferenceException();

            user.Logout();
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
