using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.User
{
    public class UpdateUserAvatarDto
    {
        public IFormFile Avatar { get; set; }
    }
}
