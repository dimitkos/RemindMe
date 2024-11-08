using System.ComponentModel.DataAnnotations;

namespace Application.Configurations
{
    public class SmtpSettings
    {
        [Required]
        public bool UseDefaultCredentials { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool EnableSsl { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]
        public int Timeout { get; set; }
    }
}
