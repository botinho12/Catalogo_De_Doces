using MimeKit;

namespace CatalogoDeDoces.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarEmailAsync(string destinatario, string assunto, string corpoHtml)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Catalogo de Doces", _configuration["EmailSettings:From"]));
            message.To.Add(new MailboxAddress("", destinatario));
            message.Subject = assunto;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = corpoHtml
            };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(_configuration["EmailSettings:Host"], int.Parse(_configuration["EmailSettings:Port"]), true);
                await client.AuthenticateAsync(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
