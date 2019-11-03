using Entidad.Dto.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entidad.Dto.Response.Perfil
{
    public class AlbumImagenResponseRegistrarDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public long IdGenerado { get; set; }
        public AlbumImagenResponseRegistrarDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
            IdGenerado = 0;
        }
    }
}
