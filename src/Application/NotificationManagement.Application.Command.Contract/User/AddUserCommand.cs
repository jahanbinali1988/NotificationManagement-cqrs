using MediatR;
using System;

namespace NotificationManagement.Application.Command.Contract.User
{
    public class AddUserCommand : IRequest
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public bool Sex { get; set; }
        public bool IsMarrid { get; set; }
        public bool IsActive { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
