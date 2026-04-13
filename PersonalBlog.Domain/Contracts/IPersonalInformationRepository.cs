using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Domain.Contracts
{
    public interface IPersonalInformationRepository
    {
        Task<byte> CreatePersonalInformation(PersonalInformation personalInformation, CancellationToken ct);
        IQueryable<PersonalInformation> GetPersonalInformation();
        Task UpdatePersonalInformation(PersonalInformation personalInformation);
    }
}
