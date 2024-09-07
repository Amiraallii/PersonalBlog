using PersonalBlog.Data.Context;
using PersonalBlog.Data.Models;
using PersonalBlog.Data.UnitOfWork;

namespace PersonalBlog.Web
{
    public class Class
    {


        public void GetAdmin(PersonalBlogContext db)
        {
            
                var add = new User
                {
                    FName = "User2",
                    LName = "Useri",
                    IdNumber = "1234567",
                    BirthDate = "2001/01/01",
                    CreateDate = DateTime.Now,
                    Gender = true,
                    IsActive = true,
                    Maried = false,
                    UserName = "Tstuser"
                };
                db.Users.Add(add);
                db.SaveChanges();
            
            
        }
    }
}
