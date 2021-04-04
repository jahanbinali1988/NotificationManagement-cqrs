using Common.Query;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NotificationManagement.Domain.Models.User;
using NotificationManagement.Query.Mongo.Mappers;
using NotificationManagement.Query.Mongo.Models.User.Requests;
using NotificationManagement.Query.Mongo.Models.User.Responses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Query.Mongo.Handlers.Users
{
    public class UserQueryHandler :
        IRequestHandler<GetAllUsers, PagingResult<UserModel>>,
        IRequestHandler<UserExistance, bool>
    {
        #region fields
        private readonly IMongoDatabase _database;
        #endregion

        #region ctor
        public UserQueryHandler(IMongoDatabase database)
        {
            _database = database;
        }
        #endregion

        #region methods
        public async Task<PagingResult<UserModel>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var query = _database.GetCollection<User>(nameof(User)).AsQueryable();

            query.Where(x => x.IsActive == request.Filter.IsActive);
            query.Where(a => a.IsDeleted == false);

            var users = await query
                .Skip(request.Filter.Offset)
                .Take(request.Filter.Count)
                .ToListAsync();

            var usersCount = await query.LongCountAsync();

            return users.Map(usersCount, request.Filter.Offset.ToString());
        }

        public async Task<bool> Handle(UserExistance request, CancellationToken cancellationToken)
        {
            bool flag = false;

            var query = _database.GetCollection<User>(nameof(User)).AsQueryable();
            query.Where(x => x.IsActive);
            query.Where(a => a.IsDeleted == false);
            query.Where(c => c.Mobile.Equals(request.Mobile));

            if (query.Any())
                flag = true;

            return await Task.Run(() => flag);
        }
        #endregion
    }
}
