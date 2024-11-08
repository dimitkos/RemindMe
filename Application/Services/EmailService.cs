using Application.Configurations;
using FluentEmail.Core;
using Microsoft.Extensions.Options;

namespace Application.Services
{
    interface IEmailService
    {
        Task Send(EmailType type, string email);
    }

    class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;
        private readonly EmailSettings _emailSettings;

        public EmailService(IFluentEmail fluentEmail, IOptions<EmailSettings> emailSettings)
        {
            _fluentEmail = fluentEmail;
            _emailSettings = emailSettings.Value;
        }

        public async Task Send(EmailType type, string email)
        {
            if (!_emailSettings.Emails.TryGetValue(type, out var emailContent))
                throw new ArgumentException($"No email settings found for type {type}");

            var response = await _fluentEmail
                .To(email)
                .Subject(emailContent.Subject)
                .Body(emailContent.Body)
                .SendAsync();

#warning create custom exception
            if (!response.Successful)
                throw new Exception(string.Join(", ", response.ErrorMessages));
        }
    }

#warning move to another files
    public enum EmailType
    {
        Registration,
        Delete,
        Subscribe,
        Unsubscribe
    }
}
