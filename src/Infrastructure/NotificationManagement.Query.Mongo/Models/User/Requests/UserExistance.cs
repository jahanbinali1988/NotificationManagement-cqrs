using Common.Query;
using MediatR;

namespace NotificationManagement.Query.Mongo.Models.User.Requests
{
    public class UserExistance : IRequest<bool>
    {
        public string Mobile { get; set; }
        public UserExistance(string mobile)
        {
            this.Mobile = mobile;
        }
    }
}
