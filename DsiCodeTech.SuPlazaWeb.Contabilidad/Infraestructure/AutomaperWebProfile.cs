using AutoMapper;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
using DsiCodeTech.SuPlazaWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Infraestructure
{
    public class AutomaperWebProfile: Profile
    {
        public AutomaperWebProfile()
        {
            CreateMap<ArticuloDto, ArticuloDM>().ReverseMap();
            CreateMap<UsuarioDto, UsuarioDM>().ReverseMap();
            CreateMap<ImpuestoDto, ImpuestoDM>().ReverseMap();
        }
        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }
    }
}