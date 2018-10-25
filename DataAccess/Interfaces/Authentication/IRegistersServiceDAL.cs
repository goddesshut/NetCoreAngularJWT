using EntityFrameworkCore.Extension;
using Models;

namespace DataAccess.Interfaces
{
    public interface IRegistersServiceDAL: IRepository<Registers>
    {

        bool Insert(Registers model);

    }
}
