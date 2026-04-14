using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.PersonalInformation.Query.GetPersonalInformation
{
    public class GetPersonalInformationQuery : IRequest<PersonalInformationDto>
    {
    }
}
