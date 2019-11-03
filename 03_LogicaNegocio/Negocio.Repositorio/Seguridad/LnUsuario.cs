﻿using Datos.Repositorio.Seguridad;
using Entidad.Dto.Seguridad;
using Entidad.Entidad.Seguridad;
using System.Collections.Generic;

namespace Negocio.Repositorio.Seguridad
{
    public class LnUsuario
    {
        private readonly AdUsuario _adUsuario = new AdUsuario();
        public UsuarioLoginDto ObtenerPorLogin(UsuarioCredencialesDto modelo)
        {
            return _adUsuario.ObtenerPorLogin(modelo);
        }

        public List<UsuarioObtenerDto> Obtener()
        {
            return _adUsuario.Obtener();
        }

        public Usuario ObtenerPorId(long id)
        {
            return _adUsuario.ObtenerPorId(id);
        }

        public int Registrar(UsuarioRegistrarDto modelo, ref long idNuevo)
        {
            return _adUsuario.Registrar(modelo, ref idNuevo);
        }

        public int Modificar(Usuario modelo)
        {
            return _adUsuario.Modificar(modelo);
        }

        public int Eliminar(long id)
        {
            return _adUsuario.Eliminar(id);
        }

        public int ModificarContrasenia(UsuarioCambioContraseniaDto modelo)
        {
            return _adUsuario.ModificarContrasenia(modelo);
        }

    }
}