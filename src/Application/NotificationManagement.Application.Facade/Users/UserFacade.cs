using Mapster;
using MediatR;
using NotificationManagement.Application.Command.Contract.User;
using NotificationManagement.Application.Facade.Contract.Users;
using NotificationManagement.Application.Facade.Contract.Users.Commands;
using System.Threading.Tasks;

namespace NotificationManagement.Application.Facade.Users
{
    public class UserFacade : IUserFacade
    {
        #region fields
        private readonly IMediator _mediator;
        #endregion

        #region ctor
        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region methods
        public Task AddUser(AddUserCommandDto commandDto)
        {
            var command = commandDto.Adapt<AddUserCommand>();
            return _mediator.Send(command);
        }

        public Task UpdateUser(UpdateCommandDto commandDto)
        {
            var command = commandDto.Adapt<AddUserCommand>();
            return _mediator.Send(command);
        }
        #endregion
    }
}
