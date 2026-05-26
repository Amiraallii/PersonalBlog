using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Domain.Contracts
{
    public interface IPersonalInformationRepository
    {
        Task UpsertPersonalInformationAsync(PersonalInformation personalInformation, CancellationToken ct);
        Task<PersonalInformation> GetPersonalInformationAsync(CancellationToken ct);
        Task<PersonalInformation> GetPersonalInformationNoTrackingAsync(CancellationToken ct);
        Task<List<string>> GetAllLocations(CancellationToken ct); 
    }
}
