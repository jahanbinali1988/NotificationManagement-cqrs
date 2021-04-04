using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagement.Application.Facade.Contract.Users.Commands
{
    public class UpdateCommandDto
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
