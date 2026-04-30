using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Infrastructure.Configurations
{
    public class EmailSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string ReplyTo { get; set; } = string.Empty;
    }
}
