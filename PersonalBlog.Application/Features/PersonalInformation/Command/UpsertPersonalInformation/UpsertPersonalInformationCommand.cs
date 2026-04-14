using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.PersonalInformation.Command.UpsertPersonalInformation
{
    public class UpsertPersonalInformationCommand : PersonalInformationDto, IRequest
    {
    }
}
