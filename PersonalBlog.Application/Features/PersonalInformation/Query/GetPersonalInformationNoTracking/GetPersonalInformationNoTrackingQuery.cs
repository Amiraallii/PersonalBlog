using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.PersonalInformation.Query.GetPersonalInformationNoTracking
{
    public class GetPersonalInformationNoTrackingQuery : IRequest<PersonalInformationDto>
    {
    }
}
