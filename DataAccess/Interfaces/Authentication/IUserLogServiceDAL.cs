using EntityFrameworkCore.Extension;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IUserLogServiceDAL: IRepository<UserLog>
    {
        bool ValidateLoginLog(string username, LoginType loginType);

        UserLog Create(UserLog model);
    }
}
