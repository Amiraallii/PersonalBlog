using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Application.Features.PersonalInformation.Command.UpsertPersonalInformation
{
    internal class UpsertPersonalInformationHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpsertPersonalInformationCommand>
    {
        public async Task Handle(UpsertPersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var contactInfoList = new List<ContactInfo>();
            foreach(var item in request.ContactInfo)
            {
                var contactInfo = new ContactInfo(item.ContactWayType, item.ContactWay);
                contactInfoList.Add(contactInfo);
            }
            var entity = new PersonalBlog.Domain.Entity.PersonalInformation(request.Name, request.LastName,
                request.JobTitle, request.AboutMe, contactInfoList);
            await unitOfWork.PersonalInformationRepository.UpsertPersonalInformationAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
