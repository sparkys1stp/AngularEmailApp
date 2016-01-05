
namespace EmailService.Models
{

    public class EmailMessageVM
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
