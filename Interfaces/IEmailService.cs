using TodoApi1.Models;

namespace TodoApi1.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(Mailrequest mailrequest);
    }
}
