using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Herfitk.API.SendEmail
{
    public interface IEmailService
    {
        public void SendEmail(EmailData email);
    }
}