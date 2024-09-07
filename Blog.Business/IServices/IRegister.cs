using Microsoft.AspNetCore.Identity;
using PersonalBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.IServices
{
    public interface IRegister
    {
        Task<IdentityResult> RegisterUserAsync(User user);
        Task<bool> EditUser(User user);
        Task<bool> RemoveUser(User user);
        User GetUser(User user);
        User GetUserById(long userId);
        List<User> GetUsersList();
    }
}
