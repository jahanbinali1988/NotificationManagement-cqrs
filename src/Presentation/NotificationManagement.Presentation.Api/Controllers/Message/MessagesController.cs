using System.Threading.Tasks;
using Common.AspNetCore;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationManagement.Application.Facade.Contract.Messages;
using NotificationManagement.Application.Facade.Contract.Messages.Commands;
using NotificationManagement.Presentation.Api.Messages.User.Request;

namespace NotificationManagement.Presentation.Api.Controllers.Messages
{
    public class MessagesController : BaseApiController
    {
        #region fields
        private readonly IMessageFacade _messageFacade;
        #endregion

        #region ctor
        public MessagesController(IMessageFacade messageFacade, ILogger<MessagesController> logger) : base(logger)
        {
            _messageFacade = messageFacade;
        }
        #endregion

        #region methods
        [HttpPost]
        [Route("sendmessage")]
        public async Task<ActionResult<bool>> SendMessage([FromBody] SendMessageRequest request)
        {
            var commandDto = new SendMessageCommandDto() { Content = request.Content, Title = request.Title };

            var result = await _messageFacade.SendMesssage(commandDto);

            return true;
        }
        #endregion

    }
}
