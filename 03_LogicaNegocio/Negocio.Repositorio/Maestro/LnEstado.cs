﻿using Datos.Repositorio.Maestro;
using Entidad.Dto.Maestro;
using Entidad.Entidad.Maestro;
using System.Collections.Generic;

namespace Negocio.Repositorio.Maestro
{
    public class LnEstado
    {
        private readonly AdEstado _adEstado = new AdEstado();

        public List<EstadoObtenerDto> Obtener()
        {
            return _adEstado.Obtener();
        }

        public Estado ObtenerPorId(int id)
        {
            return _adEstado.ObtenerPorId(id);
        }

        public int Registrar(EstadoRegistrarDto modelo, ref int idNuevo)
        {
            return _adEstado.Registrar(modelo, ref idNuevo);
        }

        public int Modificar(Estado modelo)
        {
            return _adEstado.Modificar(modelo);
        }

        public int Eliminar(int id)
        {
            return _adEstado.Eliminar(id);
        }

    }
}
