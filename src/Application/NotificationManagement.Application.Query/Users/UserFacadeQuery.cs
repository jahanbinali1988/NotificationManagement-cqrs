using CacheHelper;
using Common.Query;
using Microsoft.Extensions.Options;
using NotificationManagement.Application.Query.Contract.Users;
using Mapster;
using System.Threading.Tasks;
using NotificationManagement.Query.Mongo.Models.User.Requests;
using NotificationManagement.Query.Mongo.Filters;
using MediatR;

namespace NotificationManagement.Application.Query.Users
{
    public class UserFacadeQuery : IUserFacadeQuery
    {
        private readonly IMediator _mediator;
        private readonly ICacheHelper _cacheHelper;
        private readonly IOptions<CacheConfiguration> _configuration;

        public UserFacadeQuery(IMediator mediator, ICacheHelper cacheHelper, IOptions<CacheConfiguration> configuration)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
            _configuration = configuration;
        }

        public async Task<PagingResult<UserDto>> GetAllUsers(UserFilterDto filterDto)
        {
            var filters = filterDto.Adapt<UserFilter>();
            var messageRequest = new GetAllUsers(filters);

            var users = await _cacheHelper.FetchAsync(_configuration.Value.Prefix, filters, () =>
                    _mediator.Send(messageRequest), _configuration.Value.ReConstruct,
                  _configuration.Value.Expiration, _configuration.Value.Ttl);


            return users.Adapt<PagingResult<UserDto>>();
        }

        public async Task<bool> UserExistance(string mobile)
        {
            var existance = await _cacheHelper.FetchAsync(_configuration.Value.Prefix, mobile, () =>
                 _mediator.Send(new UserExistance(mobile)), _configuration.Value.ReConstruct,
                _configuration.Value.Expiration, _configuration.Value.Ttl);

            return existance;
        }
    }
}
