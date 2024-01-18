using HRMSBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTbController : ControllerBase
    {
        private readonly HumanResourceManagementContext _authcontext;
        WebAPIResponse response = new WebAPIResponse();
        bool IsError = false;


        public UsersTbController(HumanResourceManagementContext humanResourceManagementContext)
        {
            _authcontext = humanResourceManagementContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UsersTb userObj)
        {
            try
            {
                if (userObj == null || userObj.UserName == " " || userObj.UserPasword == " " || userObj.UserEmail == " ")
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = " Please Enter valid Login Credentials! ";
                    return Ok(response);
                }

                //var user = await _authcontext.UsersTbs.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.UserPasword == userObj.UserPasword);
                var user = await _authcontext.UsersTbs.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.UserPasword == userObj.UserPasword && x.UserEmail == userObj.UserEmail);


                if (user == null)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = " Invalid Login Credentials! ";
                    return Ok(response);
                }
                else
                {
                    response.Data = new 
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        UserEmail = user.UserEmail,
                    };

                    response.Success = true;
                    response.Message = " Login Successfully ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(response);
        }
        private Task<bool> CheckUserNameExistAsync(string username) => _authcontext.UsersTbs.AnyAsync(x => x.UserName == username);
        private Task<bool> CheckUserEmailExistAsync(string email) => _authcontext.UsersTbs.AnyAsync(x => x.UserEmail == email);
        
        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if(password.Length < 8)
                sb.Append(" Minimum Password length should be 8 or more than "+Environment.NewLine);
            if(!(Regex.IsMatch(password,"[a-z,A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append(" Password should be Alphanumeric " + Environment.NewLine);
            if(!Regex.IsMatch(password,"[!,@,#,$,|]"))
                sb.Append(" Password should contain Special Character[!,@,#,$,|] " + Environment.NewLine);
            return sb.ToString();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsersTb userObj)
        {
            try
            {
                if (userObj == null)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = " Invalid Register Credentials! ";
                    return Ok(response);
                }

                //Check UserName
                if (await CheckUserNameExistAsync(userObj.UserName))
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = " UserName Already Exist! ";
                    return Ok(response);
                }

                //Check Email
                if (await CheckUserEmailExistAsync(userObj.UserEmail))
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = " Email Address Already Exist! ";
                    return Ok(response);
                }

                //Check Password
                var password = CheckPasswordStrength(userObj.UserPasword);
                if (!string.IsNullOrEmpty(password))
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = password.ToString();
                    return Ok(response);
                }

                UsersTb user = new UsersTb();
                user.UserName = userObj.UserName;
                user.UserEmail = userObj.UserEmail;
                user.UserPasword = userObj.UserPasword;

                await _authcontext.UsersTbs.AddAsync(user);
                await _authcontext.SaveChangesAsync();

                response.Success = true;
                response.Message = " Register Successfully ";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Ok(response);
        }

    }
}
