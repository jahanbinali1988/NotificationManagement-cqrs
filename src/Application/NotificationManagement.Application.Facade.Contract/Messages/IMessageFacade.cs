using System.Threading.Tasks;
using NotificationManagement.Application.Facade.Contract.Messages.Commands;

namespace NotificationManagement.Application.Facade.Contract.Messages
{
    public interface IMessageFacade
    {
        Task<bool> SendMesssage(SendMessageCommandDto commandDto);
    }
}
