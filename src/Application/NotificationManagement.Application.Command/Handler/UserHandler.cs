using MediatR;
using MongoDB.Driver;
using NotificationManagement.Application.Command.Contract.User;
using NotificationManagement.Domain.Models.User;
using NotificationManagement.Persistence.Mongo.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationManagement.Application.Command.Handler
{
    public class UserHandler :
        AsyncRequestHandler<AddUserCommand>,
        IRequestHandler<UpdateUserCommand>
    {
        #region fields
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IUserRepository _userRepository;
        #endregion

        #region ctor
        public UserHandler(IMongoDatabase mongoDatabase, IUserRepository userRepository)
        {
            this._mongoDatabase = mongoDatabase;
            this._userRepository = userRepository;
        }
        #endregion

        #region methods
        protected override async Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (command is null)
                throw new Exception();

            var userValidator = new UserValidator(_mongoDatabase);

            var user = await User.Create(Guid.NewGuid(), command.Name, command.Family, command.Sex, command.IsMarrid, command.IsActive, command.Mobile, command.Email, command.BirthDate, userValidator);

            await this._userRepository.Create(user);
        }


        public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (command is null)
                throw new Exception();

            var userValidator = new UserValidator(_mongoDatabase);

            var user = await User.Create(command.Id, command.Name, command.Family, command.Sex, command.IsMarrid, command.IsActive, command.Mobile, command.Email, command.BirthDate, userValidator);

            await this._userRepository.Update(user);

            return await Unit.Task;
        }
        #endregion
    }
}
