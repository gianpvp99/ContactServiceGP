using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.DTO.DTOs.Request
{
    public class SendEmailReq
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string message { get; set; }
        public string ip_public { get; set; }
        public string browser_type { get; set; }
    }
}
