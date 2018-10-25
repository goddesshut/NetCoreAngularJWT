using EntityFrameworkCore.Extension;
using Models;

namespace DataAccess.Interfaces
{
    public interface IProfileServiceDAL: IRepository<Profile>
    {
        Profile Find(Profile model);
    }
}
