using System;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using NotificationManagement.Application.Facade.Contract.Messages.Mapper;
using NotificationManagement.Application.Facade.Contract.Messages;
using NotificationManagement.Application.Facade.Contract.Messages.Commands;
using NotificationManagement.Application.Query.Contract.Users;

namespace NotificationManagement.Application.Facade.Messages
{
    public class MessageFacade : IMessageFacade
    {
        #region fields
        private readonly IMediator _mediator;
        private readonly IUserFacadeQuery _userFacadeQuery;
        #endregion

        #region ctor
        public MessageFacade(IMediator mediator, IUserFacadeQuery userFacadeQuery)
        {
            _mediator = mediator;
            _userFacadeQuery = userFacadeQuery;
        }
        #endregion

        #region methods
        public async Task<bool> SendMesssage(SendMessageCommandDto commandDto)
        {
            var hasUser = true;
            Byte bulkSize = 100;
            var filter = new UserFilterDto()
            {
                Count = bulkSize,
                IsActive = true,
                Offset = 0
            };

            while (hasUser)
            {
                filter.Offset += 1;

                var users = await _userFacadeQuery.GetAllUsers(filter);
                var command = commandDto.Map(users.Data.Select(s => s.Id).ToList());

                await _mediator.Send(command);

                if ((filter.Offset * filter.Count) >= users.TotalCount)
                    hasUser = false;
            }

            return await Task.Run(() => true);
        }
        #endregion

    }
}
