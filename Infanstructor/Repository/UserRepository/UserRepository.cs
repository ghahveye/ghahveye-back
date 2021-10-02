using Application.Repositories;
using Domain.Entities;
using Domain.RequestFeature;
using Domain.RequestFeatures;
using Infanstructor.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infanstructor.Repository.UserRepository
{
    class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public UserRepository(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            var userCheck = await _userManager.CheckPasswordAsync(user, password);
            return userCheck;
        }

        public async Task CreateUserAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var users = await    GetUserByIdAsync(id);
            users.IsDeleted = true;
            await  SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<PagedList<ApplicationUser>> GetAllUsersAsync(RequestParameters requestParameters)
        {
            var users = await _context.Users.Where(x=> x.IsBanned == false).Where(x=> x.IsDeleted == false).OrderByDescending(x => x.CreateDate).ToListAsync();

            return PagedList<ApplicationUser>
                .ToPagedList(users, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<ApplicationUser> GetUserByUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<Profile> GetUserProfile(Guid id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(user => user.UserId == id.ToString());
        }

        public async Task ResetPasswordAsync(Guid userId, string password)
        {
            var user = await GetUserByIdAsync(userId);
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, resetToken, password);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateAvatarAsync(string avatar,Guid id)
        {
            var user = await GetUserProfile(id);
            user.Avatar = avatar;
            await  SaveChangesAsync();
        }

        public async Task<Profile> UpdateUserAsync(Profile profile, Guid userId)
        {
            var user = await GetUserProfile(userId);
            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            user.InvationLink = profile.InvationLink;
            user.Position = profile.Position;
            user.Province = profile.Province;
            user.AboutMe = profile.AboutMe;
            user.Address = profile.Address;
            user.City = profile.City;
            user.ConvincingReasons = profile.ConvincingReasons;
            await SaveChangesAsync();
            return user;
        }
    }
}
