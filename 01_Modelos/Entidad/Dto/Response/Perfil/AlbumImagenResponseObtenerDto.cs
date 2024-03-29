﻿using Entidad.Dto.Global;
using Entidad.Dto.Perfil;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Perfil
{
    public class AlbumImagenResponseObtenerDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public List<AlbumImagenObtenerDto> Cuerpo { get; set; }
        public AlbumImagenResponseObtenerDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
        }
    }
}
