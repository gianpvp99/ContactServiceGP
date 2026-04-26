using ContactService.DTO.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Domain.Interfaces
{
    public interface IEmailRepository
    {
        Task <bool> SendEmailAsync(SendEmailReq request);
    }
}
