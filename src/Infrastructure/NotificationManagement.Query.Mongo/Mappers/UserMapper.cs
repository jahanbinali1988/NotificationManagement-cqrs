using Common.Query;
using NotificationManagement.Domain.Models.User;
using NotificationManagement.Query.Mongo.Models.User.Responses;
using System.Collections.Generic;

namespace NotificationManagement.Query.Mongo.Mappers
{
    public static class UserMapper
    {
        public static PagingResult<UserModel> Map(this List<User> sources, long userCount, string nextPage)
        {
            PagingResult<UserModel> userModels = new PagingResult<UserModel>() { TotalCount = userCount, NextUrl = nextPage, Data = new List<UserModel>() }; 

            if (sources == null)
                return userModels;

            foreach (var source in sources)
            {
                userModels.Data.Add(source.Map());
            }

            return userModels;
        }

        public static UserModel Map(this User source)
        {
            if (source != null)
                return new UserModel()
                {
                    BirthDate = source.BirthDate,
                    Email = source.Email,
                    Family = source.Family,
                    Id = source.Id,
                    IsActive = source.IsActive,
                    IsMarrid = source.IsMarrid,
                    Mobile = source.Mobile,
                    Name = source.Name,
                    Sex = source.Sex
                };

            return null;
        }
    }
}
