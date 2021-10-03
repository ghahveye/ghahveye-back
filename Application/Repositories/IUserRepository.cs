using Application.DataTransferObjects.User;
using Domain.Entities;
using Domain.RequestFeature;
using Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(ApplicationUser user,string password);
        Task<ApplicationUser> GetUserByIdAsync(Guid userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> GetUserByUserByNameAsync(string userName);
        Task<Profile> UpdateUserAsync(Profile profile, Guid userId);
        Task<Profile> GetUserProfile(Guid id);
        Task UpdateAvatarAsync(string avatar,Guid id);
        Task<bool> CheckPasswordAsync(ApplicationUser user,string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task ResetPasswordAsync(Guid userId,string password);
        Task<bool> SaveChangesAsync();
        Task<PagedList<UserForShowDto>> GetAllUsersAsync(RequestParameters requestParameters);
        Task DeleteUserAsync(Guid id);
        Task CreateProfile(Profile profile);
    }
}
