using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.User
{
    public class UserSV : IUserSV
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;
        
        public UserSV(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return "Tài khoản không tồn tại";


            //if (user!=null & await _userManager.CheckPasswordAsync(user,request.Password))
            //{
            var check = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!check)
            {
                return "Sai mật khẩu";
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            var token = new JwtSecurityToken(
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   expires: DateTime.Now.AddHours(3),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)

                    );

            return  (new JwtSecurityTokenHandler().WriteToken(token));
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserVM> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UserVM>> GetUserPaging(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UserVM>> GetUsersPaging(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public  Task<bool> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
