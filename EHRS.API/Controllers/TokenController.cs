﻿using AutoMapper;
using EHRS.API.ViewModels;
using EHRS.BLL.Abstract;
using EHRS.BLL.Models;
using EHRS.Common.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace EHRS.API.Controllers
{
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        private IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IHttpActionResult Post(LoginViewModel loginViewModel)
        {
            if (loginViewModel != null && ModelState.IsValid)
            {
                var loginModel = Mapper.Map<LoginModel>(loginViewModel);
                var userData = _userService.Login(loginModel);

                if (userData != null)
                {
                    UserAuthDataViewModel userAuthData = Mapper.Map<UserAuthDataViewModel>(userData);

                    string token = GenerateToken(userAuthData);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateToken(UserAuthDataViewModel userAuthData)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(GlobalConstants.Token_HashKey));

            List<Claim> claimsData = new List<Claim>();

            claimsData.Add(new Claim(GlobalConstants.Key_LoggedUserInfo, new JavaScriptSerializer().Serialize(userAuthData)));

            var token = new JwtSecurityToken(
                issuer: GlobalConstants.Token_Issuer,
                claims: claimsData,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(GlobalConstants.SessionTime_InMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
