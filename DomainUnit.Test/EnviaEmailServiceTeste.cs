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
            // Arrange
            var toAddress = "test@test.com";
            var subject = "Test Subject";
            var body = "Test Body";

            var mockSmtpClient = new Mock<SmtpClient>();
            mockSmtpClient
                .Setup(x => x.Send(It.IsAny<MailMessage>()))
                .Verifiable();

            // Act
            EnviaEmailService.EnviaEmail(toAddress, subject, body);

            // Assert
            mockSmtpClient.Verify(x => x.Send(It.IsAny<MailMessage>()), Times.Once);
        }
    }
}
