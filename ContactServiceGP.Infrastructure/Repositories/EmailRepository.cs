using ContactService.DTO.DTOs.Request;
using ContactServiceGP.Domain.Interfaces;
using ContactServiceGP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SendEmailAsync(SendEmailReq request)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC dbo.SP_SendEmail @fullname = {request.fullname}, @email = {request.email}, @phone = {request.phone}, @message = {request.message}, @ip_public = {request.ip_public}, @browser_type = {request.browser_type}");
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
