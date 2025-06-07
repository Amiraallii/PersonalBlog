using Personal.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Application.IServices
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAll(CancellationToken ct);
        Task<Post> GetById(Guid id, CancellationToken ct);
        Task Add(Post post , CancellationToken ct);
        Task Delete(Guid id, CancellationToken ct);
    }
}
