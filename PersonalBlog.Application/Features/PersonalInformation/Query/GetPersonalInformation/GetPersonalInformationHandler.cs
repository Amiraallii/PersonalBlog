using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.PersonalInformation.Query.GetPersonalInformation
{
    public class GetPersonalInformationHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonalInformationQuery, PersonalInformationDto>
    {
        public async Task<PersonalInformationDto> Handle(GetPersonalInformationQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.PersonalInformationRepository.GetPersonalInformationAsync(cancellationToken);
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
