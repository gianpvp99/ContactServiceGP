using AutoMapper;
using ContactService.DTO.DTOs.Request;
using ContactServiceGP.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Application.Commands.Handlers
{
    public class SendEmailHandler : IRequestHandler<SendEmailCommand, bool>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        public SendEmailHandler(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var responseDTO = _mapper.Map<SendEmailReq>(request);
            var repository = await _emailRepository.SendEmailAsync(responseDTO);
            return true;
        }
    }
}
