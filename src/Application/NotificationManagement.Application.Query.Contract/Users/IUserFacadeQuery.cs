using Common.Query;
using System.Threading.Tasks;

namespace NotificationManagement.Application.Query.Contract.Users
{
    public interface IUserFacadeQuery
    {
        Task<PagingResult<UserDto>> GetAllUsers(UserFilterDto filterDto);
        Task<bool> UserExistance(string mobile);
    }
}
