using BussinessLogic.Base;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Models;
using Models.Enums;
using Models.ViewModels;
using Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Services
{
    public class AuthenticateServiceBLL: BaseBussinessLogic, IAuthenticateServiceBLL
    {
        protected readonly IHash Hash;

        protected readonly IJsonWebToken JsonWebToken;

        protected readonly IProfileServiceDAL ProfileServiceDAL;

        protected readonly IUserLogServiceDAL UserLogServiceDAL;

        public AuthenticateServiceBLL(IHash hash, IJsonWebToken jsonWebToken, IProfileServiceDAL profileServiceDAL, IUserLogServiceDAL userLogServiceDAL)
        {
            this.Hash = hash;
            this.JsonWebToken = jsonWebToken;
            this.ProfileServiceDAL = profileServiceDAL;
            this.UserLogServiceDAL = userLogServiceDAL;
        }

        public string Authenticate(AuthenticationViewModel model)
        {
            try
            {
                var profile = new Profile();
                profile.Username = model.username;
                profile.Password = this.Hash.Create(model.password);

                var profileModel = this.ProfileServiceDAL.Find(profile);
                if(profileModel == null)
                {
                    throw new UnauthorizedAccessException();
                }

                //var validateUserLog = this.UserLogServiceDAL.ValidateLoginLog(model.username, LoginType.Login);
                //if (!validateUserLog)
                //{
                //    throw new UnauthorizedAccessException();
                //}

                var userLog = new UserLog();
                userLog.Username = model.username;
                userLog.ELoginType = LoginType.Login;
                userLog.LoginType = LoginType.Login.ToString();
                userLog.CreateDate = DateTime.Now;

                var logModel = this.UserLogServiceDAL.Create(userLog);

                var auth = new AuthenticationViewModel();
                auth.username = profileModel.Username;

                string token = this.GenerateJwt(auth);

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateJwt(AuthenticationViewModel model)
        {
            string[] roles = new string[] { "admin" };

            var result = this.JsonWebToken.Encode(model.username, roles);
            return result;
        }

        public void Logout(string username)
        {
            var userLog = new UserLog();
            userLog.Username = username;
            userLog.ELoginType = LoginType.Logout;
            userLog.LoginType = LoginType.Logout.ToString();
            userLog.CreateDate = DateTime.Now;

            this.UserLogServiceDAL.Create(userLog);
        }

    }
}
