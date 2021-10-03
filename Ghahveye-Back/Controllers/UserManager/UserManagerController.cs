using Application.Contracts;
using Application.DataTransferObjects.User;
using Domain.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ghahveye_Back.Controllers.UserManager
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public UserManagerController(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var res = await _userBusinessLogic.GetUserAsync(id);
            return res.Success ? StatusCode(res.Status, res) : StatusCode(res.Status, res);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery]RequestParameters requestParameters)
        {
            var res = await _userBusinessLogic.GetAllUserAsync(requestParameters);
            return res.Success ? StatusCode(res.Status, res) : StatusCode(res.Status, res);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(UserForUpdateDto userForUpdateDto, Guid id)
        {
            var res = await _userBusinessLogic.UpdateUserAsync(userForUpdateDto, id);
            return res.Success ? StatusCode(res.Status, res) : StatusCode(res.Status, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateUserAvatarDto updateUserAvatarDto, Guid id)
        {
            var res = await _userBusinessLogic.UpdateAvatarAsync(updateUserAvatarDto, id);
            return res.Success ? StatusCode(res.Status, res) : StatusCode(res.Status, res);
        }
    }
}
