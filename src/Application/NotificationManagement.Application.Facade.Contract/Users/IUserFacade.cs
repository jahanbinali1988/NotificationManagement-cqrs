using System.Threading.Tasks;
using NotificationManagement.Application.Facade.Contract.Users.Commands;

namespace NotificationManagement.Application.Facade.Contract.Users
{
    public interface IUserFacade
    {
        Task AddUser(AddUserCommandDto commandDto);
        Task UpdateUser(UpdateCommandDto commandDto);
    }
}
