using Common.Query;
using MediatR;
using NotificationManagement.Query.Mongo.Filters;
using NotificationManagement.Query.Mongo.Models.User.Responses;

namespace NotificationManagement.Query.Mongo.Models.User.Requests
{
    public class GetAllUsers : IRequest<PagingResult<UserModel>>
    {
        public UserFilter Filter { get; set; }

        public GetAllUsers(UserFilter filter)
        {
            this.Filter = filter;
        }
    }
}
