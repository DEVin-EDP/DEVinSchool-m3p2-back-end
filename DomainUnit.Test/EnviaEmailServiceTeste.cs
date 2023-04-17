using Domain.Service;
using Moq;
using System.Net.Mail;

namespace DomainUnit.Test
{
    public class EnviaEmailServiceTeste
    {
        [Test]
        public void EnviaEmail_DeveEnviarEmailComSucesso()
        {
            var toAddress = "test@test.com";
            var subject = "Test Subject";
            var body = "Test Body";

            var mockSmtpClient = new Mock<SmtpClient>();
            mockSmtpClient
                .Setup(x => x.Send(It.IsAny<MailMessage>()))
                .Verifiable();
            
            EnviaEmailService.EnviaEmail(toAddress, subject, body);
            mockSmtpClient.Verify(x => x.Send(It.IsAny<MailMessage>()), Times.Once);
        }
    }
}
