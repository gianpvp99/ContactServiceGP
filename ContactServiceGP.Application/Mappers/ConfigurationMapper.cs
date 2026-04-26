using AutoMapper;
using ContactService.DTO.DTOs.Request;
using ContactServiceGP.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactServiceGP.Application.Mappers
{
    public class ConfigurationMapper: Profile
    {
        public ConfigurationMapper() {

            //Agregar los mappers
            //La estructura es la siguiente CreateMap<Proviene,Destino>();
            CreateMap<SendEmailCommand,SendEmailReq>();
        }
        
    }
}
