using Mvc.Mailer;
using MvcDemos.Mailers.Models;

namespace MvcDemos.Mailers
{ 
    public interface IPasswordResetMailer
    {
			MvcMailMessage PasswordReset(MailerModel model);
	}
}