using Blog.Business.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using PersonalBlog.Data.Context;
using PersonalBlog.Data.Models;
using PersonalBlog.Data.UnitOfWork;

namespace Blog.Business.Services
{
    public class Register : IRegister
    {
        private readonly PersonalBlogContext _context;
        private readonly UnitOfWork db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public Register(PersonalBlogContext context)
        {
            _context = context;
            db = new UnitOfWork(context);
        }
        public async Task<bool> EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersList()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUserAsync(User user)
        {
            var Iuser = new IdentityUser()
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(Iuser, user.Password);
            
            if (result.Succeeded)
            {
                db.Users.Add(user);
                return result;
            }else
            {
                return result;
            }
        }

        public async Task<bool> RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        
    }
}
