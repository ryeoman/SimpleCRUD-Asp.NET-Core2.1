using AutoMapper;
using Medico.Challange.DL.Entities;
using Medico.Challange.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medico.Challange.Services.Mappers
{
    public class AutoMapperBootStrapper
    {

        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Patient, PatientViewModel>().ReverseMap();

            });
        }
    }
}
