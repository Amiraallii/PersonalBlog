using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.WebApi.Controllers
{
    public class PersonalController : ControllerBase
    {
        protected Guid CurrentUserId
        {
            get
            {
                var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (Guid.TryParse(userIdString, out var userId))
                    return userId;

                return new();
            }
        }
    }
}
