using Application.Contracts;
using Application.EntityMapping.User;
using Application.Implementation;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Ghahveye_Back.Controllers.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public AuthenticationController(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;

        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var res = await _userBusinessLogic.LoginUserAsync(loginDto);
            return res.Success ? StatusCode(res.Status,res) : StatusCode(res.Status,res);
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDo)
        {
            var res = await _userBusinessLogic.RegisterUserAsync(registerDo);
            return res.Success ? StatusCode(res.Status, res) : StatusCode(res.Status, res);
        }

    }
}
