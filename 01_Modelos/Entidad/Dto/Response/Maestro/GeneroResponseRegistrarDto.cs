using Entidad.Dto.Global;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entidad.Dto.Response.Maestro
{
    public class GeneroResponseRegistrarDto
    {
        public bool ProcesadoOk { get; set; }
        [DisplayName("ListaErrores")]
        public List<ErrorDto> ListaError { get; set; }
        public int IdGenerado { get; set; }
        public GeneroResponseRegistrarDto()
        {
            ProcesadoOk = false;
            ListaError = new List<ErrorDto>();
            IdGenerado = 0;
        }
    }
}
