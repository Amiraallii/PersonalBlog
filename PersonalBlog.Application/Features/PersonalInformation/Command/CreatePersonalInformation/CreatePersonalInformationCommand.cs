using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.PersonalInformation.Command.CreatePersonalInformation
{
    public class CreatePersonalInformationCommand : CreatePersonalInformationDto, IRequest<byte>
    {
    }
}
