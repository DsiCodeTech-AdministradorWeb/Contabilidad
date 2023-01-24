﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Dto
{
    public class ResponseWrapper<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}