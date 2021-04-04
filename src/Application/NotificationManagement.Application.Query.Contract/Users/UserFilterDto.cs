namespace NotificationManagement.Application.Query.Contract.Users
{
    public class UserFilterDto
    {
        public bool IsActive { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
