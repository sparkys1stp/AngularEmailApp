using System.Web.Http;
using EmailService.Models;

namespace EmailWebAPI.Controllers
{
     [RoutePrefix("api/email")]
    public class EmailController : ApiController
    {

        [HttpPost, Route("send")]
        public IHttpActionResult Send(EmailMessageVM emailVM)
        {
            emailVM.FromEmail = "hardcode@email.com";
            var emailService = new EmailService.EmailService();

            emailService.Email(emailVM);

            return Ok();
        }
    }
}
