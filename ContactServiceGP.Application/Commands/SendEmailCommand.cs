using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Application.Commands
{
    public class SendEmailCommand:IRequest<bool>
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string message { get; set; }
    }
}
