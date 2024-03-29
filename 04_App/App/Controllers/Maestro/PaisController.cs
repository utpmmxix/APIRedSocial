﻿using System.Threading.Tasks;
using AutoMapper;
using Entidad.Dto.Global;
using Entidad.Dto.Maestro;
using Entidad.Dto.Response.Maestro;
using Entidad.Entidad.Maestro;
using Microsoft.AspNetCore.Mvc;
using Negocio.Repositorio.Maestro;

namespace App.Controllers.Maestro
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PaisController : ControllerBase
    {
        private readonly LnPais _lnPais = new LnPais();
        private readonly IMapper mapper;

        public PaisController(IMapper _mapper)
        {
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PaisResponseObtenerDto>> Obtener()
        {
            PaisResponseObtenerDto respuesta = new PaisResponseObtenerDto();
            var result = await Task.FromResult(_lnPais.Obtener());
            respuesta.ProcesadoOk = true;
            respuesta.Cuerpo = result;
            return Ok(respuesta);
        }

        [HttpGet("{id}", Name = "ObtenerPaisPorId")]
        [ProducesResponseType(typeof(PaisResponseObtenerPorIdDto), 404)]
        [ProducesResponseType(typeof(PaisResponseObtenerPorIdDto), 200)]
        public async Task<ActionResult<PaisResponseObtenerPorIdDto>> ObtenerPorId(int id)
        {
            PaisResponseObtenerPorIdDto respuesta = new PaisResponseObtenerPorIdDto();
            var entidad = await Task.FromResult(_lnPais.ObtenerPorId(id));
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
        [ProducesResponseType(typeof(PaisResponseRegistrarDto), 400)]
        [ProducesResponseType(typeof(PaisResponseRegistrarDto), 200)]
        public async Task<ActionResult<PaisResponseRegistrarDto>> Registrar([FromBody] PaisRegistrarDto modelo)
        {
            PaisResponseRegistrarDto respuesta = new PaisResponseRegistrarDto();
            if (!ModelState.IsValid)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Los parametros enviados no son correctos" });
                return BadRequest(respuesta);
            }

            int nuevoId = 0;
            var result = await Task.FromResult(_lnPais.Registrar(modelo, ref nuevoId));
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
        [ProducesResponseType(typeof(PaisResponseModificarDto), 404)]
        [ProducesResponseType(typeof(PaisResponseModificarDto), 400)]
        [ProducesResponseType(typeof(PaisResponseModificarDto), 200)]
        public async Task<ActionResult<PaisResponseModificarDto>> Modificar(int id, [FromBody] Pais modelo)
        {
            PaisResponseModificarDto respuesta = new PaisResponseModificarDto();
            if (!ModelState.IsValid)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Los parametros enviados no son correctos" });
                return BadRequest(respuesta);
            }

            var entidad = await Task.FromResult(_lnPais.ObtenerPorId(modelo.IdPais));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            var result = await Task.FromResult(_lnPais.Modificar(modelo));
            if (result == 0)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Error al intentar modificar" });
                return BadRequest(respuesta);
            }

            respuesta.ProcesadoOk = true;
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PaisResponseEliminarDto), 404)]
        [ProducesResponseType(typeof(PaisResponseEliminarDto), 400)]
        [ProducesResponseType(typeof(PaisResponseEliminarDto), 200)]
        public async Task<ActionResult<PaisResponseEliminarDto>> Eliminar(int id)
        {
            PaisResponseEliminarDto respuesta = new PaisResponseEliminarDto();
            var entidad = await Task.FromResult(_lnPais.ObtenerPorId(id));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            int result = await Task.FromResult(_lnPais.Eliminar(id));
            if (result == 0)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Error al intentar eliminar el registro" });
                return BadRequest(respuesta);
            }

            respuesta.ProcesadoOk = true;
            return Ok(respuesta);
        }
    }
}
