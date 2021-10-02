using Application.DataTransferObjects.User;
using Application.EntityMapping.User;
using Domain.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserBusinessLogic
    {
        Task<IBusinessLogicResult> RegisterUserAsync(RegisterDto registerDto);
        Task<IBusinessLogicResult<TokensForShowDto>> LoginUserAsync(LoginDto loginDto);
        Task<IBusinessLogicResult> VerificateEmailAsync(Guid id);
        Task<IBusinessLogicResult> ForgetPass(ForgetPassDto forgetPassDto);
        Task<IBusinessLogicResult> ResetPass(ResetPasswordDto resetPasswordDto, Guid userId);
        Task<IBusinessLogicResult<TokensForShowDto>> RefreshAsync(TokensForRefreshDto tokensForRefreshDto, Guid userId);
        Task<IBusinessLogicResult<TokensForShowDto>> UpdateUserAsync(UserForUpdateDto userForUpdateDto, string userName, Guid userId);
        Task<IBusinessLogicResult<TokensForShowDto>> AdminUpdateUserAsync(UserForUpdateDto userForUpdateDto, string userName, Guid userId);
        Task<IBusinessLogicResult> UpdateAvatarAsync(UpdateUserAvatarDto updateUserAvatarDto, Guid userId);
        Task<IBusinessLogicResult<UserForShowDto>> GetUserAsync(string userName);
        Task<IBusinessLogicResult<UserForShowDto>> GetAllUserAsync(RequestParameters requestParameters);
        Task<IBusinessLogicResult<UserForShowDto>> GetUserByIdAsyncAdmin(Guid id);
        Task<IBusinessLogicResult> DeleteUserAsync(Guid id);
    }
}
