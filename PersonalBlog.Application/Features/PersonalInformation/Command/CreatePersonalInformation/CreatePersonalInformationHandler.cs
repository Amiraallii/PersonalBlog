using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Application.Features.PersonalInformation.Command.CreatePersonalInformation
{
    public class CreatePersonalInformationHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreatePersonalInformationCommand, byte>
    {
        public async Task<byte> Handle(CreatePersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entity.PersonalInformation(request.Name, request.LastName, request.JobTitle, request.AboutMe);
            foreach (var item in request.ContactInfos)
            {
                var newContactInfo = new ContactInfo(item.ContactWayType, item.ContactWay);
                entity.AddContactInfo(newContactInfo);
            }
            return await unitOfWork.PersonalInformationRepository.CreatePersonalInformation(entity, cancellationToken);  
        }
    }
}
