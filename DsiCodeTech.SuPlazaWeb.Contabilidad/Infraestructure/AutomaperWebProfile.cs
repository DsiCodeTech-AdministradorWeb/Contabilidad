using AutoMapper;
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