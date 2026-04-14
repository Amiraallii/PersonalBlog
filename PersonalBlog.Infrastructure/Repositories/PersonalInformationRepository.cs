using Microsoft.EntityFrameworkCore;
using Personal.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class PersonalInformationRepository(ApplicationDbContext _context) : IPersonalInformationRepository
    {
        public async Task UpsertPersonalInformationAsync(PersonalInformation personalInformation, CancellationToken ct)
        {
            await _context.PersonalInformations.ExecuteDeleteAsync(ct);

            await _context.PersonalInformations.
                AddAsync(personalInformation, ct);
        }

        public async Task<PersonalInformation> GetPersonalInformationAsync(CancellationToken ct)
        {
            return await _context.PersonalInformations
                .Include(x => x.ContactInfos)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<PersonalInformation> GetPersonalInformationNoTrackingAsync(CancellationToken ct)
        {
            return await _context.PersonalInformations
                .Include(x=> x.ContactInfos)
                .AsNoTracking()
                .FirstOrDefaultAsync(ct);
        }
    }
}
