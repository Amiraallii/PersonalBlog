using Microsoft.EntityFrameworkCore;
using Personal.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class PersonalInformationRepository(ApplicationDbContext _context) : IPersonalInformationRepository
    {
        public async Task<byte> CreatePersonalInformation(PersonalInformation personalInformation, CancellationToken ct)
        {
            await _context.PersonalInformations.AddAsync(personalInformation, ct);

            return personalInformation.Id;
        }

        public IQueryable<PersonalInformation> GetPersonalInformation()
        {
            return _context.PersonalInformations
                .Include(x => x.ContactInfos)
                .AsNoTracking();
        }

        public async Task UpdatePersonalInformation(PersonalInformation personalInformation)
        {
             _context.Update(personalInformation);
        }
    }
}
