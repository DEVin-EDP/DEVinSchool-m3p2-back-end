using System.Net;
using System.Net.Mail;

namespace Domain.Service
{
    public class EnviaEmailService
    {
        public static void EnviaEmail(string toAddress, string subject, string body)
        {
            using var message = new MailMessage("devinschool@ezboard.tech", toAddress)
            {
                Subject = subject,
                Body = body
            };

            using var smtpClient = new SmtpClient("email-ssl.com.br", 587)
            {
                Credentials = new NetworkCredential("devinschool@ezboard.tech", "Devinschool@365"),
                EnableSsl = true
            };

            try
            {
                smtpClient.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}
