using System.Threading.Tasks;
using Entidad.Dto.Global;
using Entidad.Dto.Perfil;
using Entidad.Dto.Response.Perfil;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Perfil;

namespace App.Controllers.Perfil
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly LnPerfil _lnPerfil = new LnPerfil();

        [HttpGet("{id}", Name = "ObtenerPerfilPorId")]
        [ProducesResponseType(typeof(PerfilResponseObtenerPorIdDto), 404)]
        [ProducesResponseType(typeof(PerfilResponseObtenerPorIdDto), 200)]
        public async Task<ActionResult<PerfilResponseObtenerPorIdDto>> ObtenerPorId(long id)
        {
            PerfilResponseObtenerPorIdDto respuesta = new PerfilResponseObtenerPorIdDto();
            var entidad = await Task.FromResult(_lnPerfil.ObtenerPorId(id));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            respuesta.ProcesadoOk = true;
            respuesta.Cuerpo = entidad;
            return Ok(respuesta);
        }


        [HttpPost]
        [ProducesResponseType(typeof(PerfilResponseRegistrarDto), 400)]
        [ProducesResponseType(typeof(PerfilResponseRegistrarDto), 200)]
        public async Task<ActionResult<PerfilResponseRegistrarDto>> Registrar([FromBody] PerfilRegistrarDto modelo)
        {
            PerfilResponseRegistrarDto respuesta = new PerfilResponseRegistrarDto();
            if (!ModelState.IsValid)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Los parametros enviados no son correctos" });
                return BadRequest(respuesta);
            }

            long nuevoId = 0;
            var result = await Task.FromResult(_lnPerfil.Registrar(modelo, ref nuevoId));
            if (result == 0)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Error al intentar registrar" });
                return BadRequest(respuesta);
            }

            respuesta.ProcesadoOk = true;
            respuesta.IdGenerado = nuevoId;

            return Ok(respuesta);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PerfilResponseModificarDto), 404)]
        [ProducesResponseType(typeof(PerfilResponseModificarDto), 400)]
        [ProducesResponseType(typeof(PerfilResponseModificarDto), 200)]
        public async Task<ActionResult<PerfilResponseModificarDto>> Modificar(int id, [FromBody] PerfilModificarDto modelo)
        {
            PerfilResponseModificarDto respuesta = new PerfilResponseModificarDto();
            if (!ModelState.IsValid)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Los parametros enviados no son correctos" });
                return BadRequest(respuesta);
            }

            var entidad = await Task.FromResult(_lnPerfil.ObtenerPorId(modelo.IdPerfil));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            var result = await Task.FromResult(_lnPerfil.Modificar(modelo));
            if (result == 0)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Error al intentar modificar" });
                return BadRequest(respuesta);
            }

            respuesta.ProcesadoOk = true;
            return Ok(respuesta);
        }


        [HttpGet("ObtenerPorIdUsuario/{idUsuario}")]
        [ProducesResponseType(typeof(PerfilResponseObtenerPorIdUsuarioDto), 404)]
        [ProducesResponseType(typeof(PerfilResponseObtenerPorIdUsuarioDto), 200)]
        public async Task<ActionResult<PerfilResponseObtenerPorIdUsuarioDto>> ObtenerPorIdUsuario(long idUsuario)
        {
            PerfilResponseObtenerPorIdUsuarioDto respuesta = new PerfilResponseObtenerPorIdUsuarioDto();
            var entidad = await Task.FromResult(_lnPerfil.ObtenerPorIdUsuario(idUsuario));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            respuesta.ProcesadoOk = true;
            respuesta.Cuerpo = entidad;
            return Ok(respuesta);
        }
    }
}
