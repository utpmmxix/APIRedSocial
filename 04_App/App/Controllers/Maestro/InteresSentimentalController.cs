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
    public class InteresSentimentalController : ControllerBase
    {
        private readonly LnInteresSentimental _lnInteresSentimental = new LnInteresSentimental();
        private readonly IMapper mapper;

        public InteresSentimentalController(IMapper _mapper)
        {
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<InteresSentimentalResponseObtenerDto>> Obtener()
        {
            InteresSentimentalResponseObtenerDto respuesta = new InteresSentimentalResponseObtenerDto();
            var result = await Task.FromResult(_lnInteresSentimental.Obtener());
            respuesta.ProcesadoOk = true;
            respuesta.Cuerpo = result;
            return Ok(respuesta);
        }

        [HttpGet("{id}", Name = "ObtenerInteresSentimentalPorId")]
        [ProducesResponseType(typeof(InteresSentimentalResponseObtenerPorIdDto), 404)]
        [ProducesResponseType(typeof(InteresSentimentalResponseObtenerPorIdDto), 200)]
        public async Task<ActionResult<InteresSentimentalResponseObtenerPorIdDto>> ObtenerPorId(int id)
        {
            InteresSentimentalResponseObtenerPorIdDto respuesta = new InteresSentimentalResponseObtenerPorIdDto();
            var entidad = await Task.FromResult(_lnInteresSentimental.ObtenerPorId(id));
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
        [ProducesResponseType(typeof(InteresSentimentalResponseRegistrarDto), 400)]
        [ProducesResponseType(typeof(InteresSentimentalResponseRegistrarDto), 200)]
        public async Task<ActionResult<InteresSentimentalResponseRegistrarDto>> Registrar([FromBody] InteresSentimentalRegistrarDto modelo)
        {
            InteresSentimentalResponseRegistrarDto respuesta = new InteresSentimentalResponseRegistrarDto();
            if (!ModelState.IsValid)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Los parametros enviados no son correctos" });
                return BadRequest(respuesta);
            }

            int nuevoId = 0;
            var result = await Task.FromResult(_lnInteresSentimental.Registrar(modelo, ref nuevoId));
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
        [ProducesResponseType(typeof(InteresSentimentalResponseModificarDto), 404)]
        [ProducesResponseType(typeof(InteresSentimentalResponseModificarDto), 400)]
        [ProducesResponseType(typeof(InteresSentimentalResponseModificarDto), 200)]
        public async Task<ActionResult<InteresSentimentalResponseModificarDto>> Modificar(int id, [FromBody] InteresSentimental modelo)
        {
            InteresSentimentalResponseModificarDto respuesta = new InteresSentimentalResponseModificarDto();
            if (!ModelState.IsValid)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Los parametros enviados no son correctos" });
                return BadRequest(respuesta);
            }

            var entidad = await Task.FromResult(_lnInteresSentimental.ObtenerPorId(modelo.IdInteresSentimental));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            var result = await Task.FromResult(_lnInteresSentimental.Modificar(modelo));
            if (result == 0)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Error al intentar modificar" });
                return BadRequest(respuesta);
            }

            respuesta.ProcesadoOk = true;
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(InteresSentimentalResponseEliminarDto), 404)]
        [ProducesResponseType(typeof(InteresSentimentalResponseEliminarDto), 400)]
        [ProducesResponseType(typeof(InteresSentimentalResponseEliminarDto), 200)]
        public async Task<ActionResult<InteresSentimentalResponseEliminarDto>> Eliminar(int id)
        {
            InteresSentimentalResponseEliminarDto respuesta = new InteresSentimentalResponseEliminarDto();
            var entidad = await Task.FromResult(_lnInteresSentimental.ObtenerPorId(id));
            if (entidad == null)
            {
                respuesta.ListaError.Add(new ErrorDto { Mensaje = "Objeto no encontrado con el ID proporcionado" });
                return NotFound(respuesta);
            }

            int result = await Task.FromResult(_lnInteresSentimental.Eliminar(id));
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
