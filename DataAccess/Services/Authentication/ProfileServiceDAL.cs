using DataAccess.Interfaces;
using EntityFrameworkCore.Extension;
using Infrastructure.Database;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services
{
    public class ProfileServiceDAL: EntityFrameworkCoreRepository<Profile>, IProfileServiceDAL
    {
        public ProfileServiceDAL(AuthDbContext context) : base(context)
        {

        }

        public Profile Find(Profile model)
        {
            try
            {
                return base.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password && x.IsActive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
