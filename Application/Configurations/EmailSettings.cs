using Application.Services;
using System.ComponentModel.DataAnnotations;

namespace Application.Configurations
{
    public class EmailContent
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }

    public class EmailSettings
    {
        public Dictionary<EmailType, EmailContent> Emails { get; set; }

    }
}
