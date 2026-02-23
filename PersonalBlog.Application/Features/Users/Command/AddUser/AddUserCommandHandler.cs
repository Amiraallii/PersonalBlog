using MediatR;
using Personal.Application.Dtos;
using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using Personal.Domain.Enums;

namespace PersonalBlog.Application.Features.Users.Command.AddUser
{
    public class AddUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddUserCommand, ResultDto>
    {
        public async Task<ResultDto> Handle(AddUserCommand request, CancellationToken ct)
        {
            var existingEmail = await unitOfWork.UserRepository.GetUserByEmailAsync(request.Email, ct);
            if (existingEmail != null)
            {
                return new ResultDto { IsSuccess = false, Message = "ایمیل تکراری است" };
            }
            var existingUser = await unitOfWork.UserRepository.GetUserByUserNameAsync(request.UserName, ct);
            if (existingUser != null)
            {
                return new ResultDto { IsSuccess = false, Message = "نام کاربری تکراری است" };
            }
            var userRole = await unitOfWork.UserRepository.GetRoleByNameAsync(UserRole.User.ToString(), ct);

            var user = new User
            (
                request.FullName,
                request.Email,
                request.UserName,
                BCrypt.Net.BCrypt.HashPassword(request.Password),
                userRole.Id,
                userRole
            );

            await unitOfWork.UserRepository.AddUserAsync(user, ct);

            await unitOfWork.SaveChangesAsync(ct);
            return new ResultDto { IsSuccess = true, Message = "کاربر با موفقیت ساخته شد" };

        }
    }
}
