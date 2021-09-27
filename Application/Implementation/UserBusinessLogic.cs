using Application.Contracts;
using Application.DataTransferObjects.User;
using Application.EntityMapping.User;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Authenticate;
using Application.Services;

namespace Application.Implementation
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly IUserRepository _repository;
        private readonly IAuth _auth;
        private readonly IMapper _mapper;

        public UserBusinessLogic(IUserRepository repository, IAuth auth, IMapper mapper)
        {
            _repository = repository;
            _auth = auth;
            _mapper = mapper;
        }
        public async Task<IBusinessLogicResult> ForgetPass(ForgetPassDto forgetPassDto)
        {
            var user = await _repository.GetUserByEmailAsync(forgetPassDto.Email);

            if (user != null && user.EmailConfirmed)
            {
                EmailService.Send(forgetPassDto.Email, "تغییر رمز عبور", $"<h1>سلام دوست م</h1> <p>برای تغییر رمز عبور خود بر روی لینک زیر کلیک کنید</p> <br></br> <a href='ghahveye.ir/resetpass/{user.Id}'>تغییر رمز</a>");
                return new BusinessLogicResult<UserForShowDto>() { Status = 200, Success = true, Message = BusinessLogicMessages.User.EmailSended, Error = null };
            }
            else
            {
                return new BusinessLogicResult<UserForShowDto>() { Status = 404, Success = false, Error = BusinessLogicErrors.User.UserDoesNotExist };
            }
        }



        public async Task<IBusinessLogicResult<UserForShowDto>> GetUserAsync(string userName)
        {
            var user = await _repository.GetUserByUserByNameAsync(userName);
            if (user is null) return new BusinessLogicResult<UserForShowDto>() { Status = 404, Success = false, Error = BusinessLogicErrors.User.UserDoesNotExist };
            var userForShow = _mapper.Map<UserForShowDto>(user);
            return new BusinessLogicResult<UserForShowDto>() { Status = 200, Success = true, Error = null, Result = userForShow };
        }

        public async Task<IBusinessLogicResult<TokensForShowDto>> LoginUserAsync(LoginDto loginDto)
        {
            var user = await _repository.GetUserByEmailAsync(loginDto.Email);
            if (!user.EmailConfirmed)
            {
                return new BusinessLogicResult<TokensForShowDto>() { Status = 400, Error = BusinessLogicErrors.User.VerifyEmail, Success = false };

            }
            else if (user != null && await _repository.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await _repository.GetRolesAsync(user);

                var accessToken = _auth.CreateAccessToken(user, userRoles);
                var refreshToken = _auth.CreateRefreshToken();
                var result = new { AccessToken = accessToken, RefreshToken = refreshToken };
                return new BusinessLogicResult<TokensForShowDto>() { Status = 200, Message = $" کاربر عزیز  {user.UserName} با موفقیت وارد شدید", Error = null, Success = true, Result = _mapper.Map<TokensForShowDto>(result) };
            }
            else
            {
                return new BusinessLogicResult<TokensForShowDto>() { Status = 404, Error = BusinessLogicErrors.User.UserDoesNotExist, Success = false };
            }
        }

        public async Task<IBusinessLogicResult<TokensForShowDto>> RefreshAsync(TokensForRefreshDto tokensForRefreshDto, Guid userId)
        {
            var user = await _repository.GetUserByIdAsync(userId);
            if (user != null)
            {
                string accessToken = tokensForRefreshDto.AccessToken;
                string refreshToken = tokensForRefreshDto.RefreshToken;
                var principal = _auth.GetPrincipalFromExpiredToken(accessToken);
                var username = principal.Identity.Name; //this is mapped to the Name claim by default
                var userByName = await _repository.GetUserByUserByNameAsync(username);
                var userRoles = _repository.GetRolesAsync(user);

                if (user == null || userByName.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    return new BusinessLogicResult<TokensForShowDto>() { Status = 401, Error = BusinessLogicErrors.User.UserDoesNotExistOrRefreshTokenIsInvalid, Success = false };
                }
                var newAccessToken = _auth.CreateAccessToken(userByName, (IList<string>)userRoles);
                var newRefreshToken = _auth.CreateRefreshToken();
                user.RefreshToken = newRefreshToken;

                return new BusinessLogicResult<TokensForShowDto>() { Status = 200, Success = true, Result = _mapper.Map<TokensForShowDto>(new { AccessToken = newAccessToken, RefreshToken = newRefreshToken }) };

            }
            else
            {
                return new BusinessLogicResult<TokensForShowDto>() { Status = 401, Error = BusinessLogicErrors.User.UserDoesNotExistOrRefreshTokenIsInvalid, Success = false };
            }
        }

        public async Task<IBusinessLogicResult> RegisterUserAsync(RegisterDto registerDto)
        {

            var userByEmail = await _repository.GetUserByEmailAsync(registerDto.Email);
            var userByUsername = await _repository.GetUserByUserByNameAsync(registerDto.UserName);
            if (userByEmail is null && userByUsername is null)
            {
                ApplicationUser User = new ApplicationUser()
                {
                    UserName = registerDto.UserName,
                    CreateDate = DateTime.UtcNow,
                    Email = registerDto.Email,
                };
                    EmailService.Send(registerDto.Email,"تایید حساب کاربری","تایید این گیخار");
                    await _repository.CreateUserAsync(User, registerDto.Password);
                    return new BusinessLogicResult() { Error = null, Message = BusinessLogicMessages.User.RegisteredSuccess, Status = 201, Success = true };


            }
            else
            {
                return new BusinessLogicResult() { Error = BusinessLogicErrors.User.UserAlreadyRegistered, Status = 201, Success = true };
            }

        }

        public Task<IBusinessLogicResult> ResetPass(ForgetPassDto forgetpassDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessLogicResult> ResetPass(ResetPasswordDto resetPasswordDto, Guid userId)
        {
            var user = await _repository.GetUserByIdAsync(userId);
            if (user != null)
            {
                EmailService.Send(user.Email, "تغییر رمز عبور", $"<h1>سلام دوست م</h1><p>رمز حساب کاربری شما تغییر کرده است،اگر از ان اطلاع ندارید به سرعت به پشتیبانی اطلاع بدهید</p>");
                await _repository.ResetPasswordAsync(userId, resetPasswordDto.Password);
                return new BusinessLogicResult<UserForShowDto>() { Status = 200, Success = true, Message = BusinessLogicMessages.User.ResetPassword, Error = null };
            }
            else
            {
                return new BusinessLogicResult<UserForShowDto>() { Status = 404, Success = false, Error = BusinessLogicErrors.User.UserDoesNotExist };
            }
        }


        public Task<IBusinessLogicResult> UpdateAvatarAsync(UpdateUserAvatarDto updateUserAvatarDto, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessLogicResult<TokensForShowDto>> UpdateUserAsync(UserForUpdateDto userForUpdateDto, string userName, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessLogicResult> VerificateEmailAsync(Guid id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.EmailConfirmed = true;
                await _repository.SaveChangesAsync();
                return new BusinessLogicResult<UserForShowDto>() { Status = 200, Success = true, Message = BusinessLogicMessages.User.VerificationEmail, Error = null };
            }
            else
            {
                return new BusinessLogicResult<UserForShowDto>() { Status = 404, Success = false, Error = BusinessLogicErrors.User.UserDoesNotExist };
            }
        }
    }
}
