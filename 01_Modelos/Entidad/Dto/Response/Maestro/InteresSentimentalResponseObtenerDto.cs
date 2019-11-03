﻿using Entidad.Dto.Global;
using Entidad.Dto.Maestro;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Maestro
{
    public class InteresSentimentalResponseObtenerDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public List<InteresSentimentalObtenerDto> Cuerpo { get; set; }
        public InteresSentimentalResponseObtenerDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
