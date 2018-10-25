using DataAccess.Interfaces;
using EntityFrameworkCore.Extension;
using Infrastructure.Database;
using Models;
using System;

namespace DataAccess.Services
{
    public class RegistersServiceDAL: EntityFrameworkCoreRepository<Registers>, IRegistersServiceDAL
    {
        public RegistersServiceDAL(AuthDbContext context): base(context)
        {
          
        }

        public bool Insert(Registers model)
        {
            try
            {
                base.Add(model);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
