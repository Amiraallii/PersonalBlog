using MediatR;
using Personal.Domain.Contracts;
using PersonalBlog.Application.Utils;
using PersonalBlog.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Application.Features.ProjectRequests.Command.AddProjectRequest
{
    public class AddProjectRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddProjectRequestCommand>
    {
        public async Task Handle(AddProjectRequestCommand request, CancellationToken cancellationToken)
        {
            var officeLocations = await unitOfWork
                .PersonalInformationRepository
                .GetAllLocations(cancellationToken);

            if (!LocationUtils.IsInRange(request.Location, officeLocations))
                throw new ValidationException("موقعیت مکانی شما در محدوده سرویس‌دهی ما نیست");

            var projectRequest = new ProjectRequest(request.Title, request.Summary, request.Location, request.PhoneNumber);
            await unitOfWork.ProjectRequestRepository.AddProjectRequestAsync(projectRequest, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
