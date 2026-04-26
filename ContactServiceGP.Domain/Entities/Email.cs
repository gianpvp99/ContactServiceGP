using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Domain.Entities
{
    public class Email
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string message { get; set; }
        public string ip_public { get; set; }
        public string browser_type { get; set; }
        public DateTime aud_date_create { get; set; }
        public DateTime aud_date_update { get; set; }
        public DateTime aud_create_user { get; set; }
        public DateTime aud_update_user { get; set; }
    }
}
