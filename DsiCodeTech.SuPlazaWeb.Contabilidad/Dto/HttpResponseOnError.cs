﻿using Newtonsoft.Json;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Dto
{
    public class HttpResponseOnError
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "message")]
        public string Description { get; set; }
    }
}