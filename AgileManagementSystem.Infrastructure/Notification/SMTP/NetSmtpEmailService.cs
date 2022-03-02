using AgileManagementSystem.Core.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Infrastructure.Notification.SMTP
{
    public class NetSmtpEmailService : IEmailService
    {
        public async Task SendSingleEmailAsync(string to, string subject, string message)
        {
            // Smptp sunucu üzerinden mail atacağımızı SmtpClient ile berliliyoruz
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // smtp 25 portu, spama düştüğü için daha güvenli olan 587 portu seçildi.
                
                Credentials = new NetworkCredential("ieanbuy.34@gmail.com", "istanbul.34"),// NetworkCredential ile hangi mail hesabı üzerinden mail atacağız kısmı
                
                EnableSsl = true, // mail gönderilirken şifreleme uygular.
            };

            try
            {
                var mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                mailMessage.To.Add(to);
                mailMessage.From = new MailAddress("ieanbuy.34@gmail.com");
                mailMessage.Body = message;

                smtpClient.Send(mailMessage);
                /* Task olan methodlarda bir response döndürmezsek bunları await Task.CompletedTask olarak işaretleyip methodun başalı bir şekilde bitmesini sağlamalıyız. */
                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
