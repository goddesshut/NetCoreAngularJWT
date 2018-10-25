using DataAccess.Interfaces;
using EntityFrameworkCore.Extension;
using Infrastructure.Database;
using Models;
using Models.Enums;
using System;

namespace DataAccess.Services
{
    public class UserLogServiceDAL: EntityFrameworkCoreRepository<UserLog>, IUserLogServiceDAL
    {
        private AuthDbContext context;

        public UserLogServiceDAL(AuthDbContext _context) : base(_context)
        {
            this.context = _context;
        }

        public bool ValidateLoginLog(string username, LoginType loginType)
        {
            try
            {
                var result = false;

                var log = base.LastOrDefault(x => x.Username == username && x.ELoginType == loginType);
                if (log == null) {
                    result = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserLog Create(UserLog model)
        {
            try
            {
                base.Add(model);
                this.context.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
