using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.PersonalInformation.Query.GetPersonalInformationNoTracking
{
    public class GetPersonalInformationNoTrackingHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonalInformationNoTrackingQuery, PersonalInformationDto>
    {
        public async Task<PersonalInformationDto> Handle(GetPersonalInformationNoTrackingQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.PersonalInformationRepository.GetPersonalInformationNoTrackingAsync(cancellationToken);
            if (entity == null)
                throw new KeyNotFoundException();

            return new PersonalInformationDto
            {
                AboutMe = entity.AboutMe,
                ContactInfo = entity.ContactInfos.Select(x => new ContactInfoDto
                {
                    ContactWay = x.ContactWay,
                    ContactWayType = x.ContactWayType
                }).ToList(),
                JobTitle = entity.JobTitle,
                LastName = entity.LastName,
                Name = entity.Name,
            };
        }
    }
}
