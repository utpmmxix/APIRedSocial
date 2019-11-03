using System;

namespace Entidad.Dto.Seguridad
{
    public class UsuarioObtenerDto
    {
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Usuario { get; set; }
        //cuidado en que metodos se retorna
        //public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DescripcionEstado { get; set; }
        public string DescripcionTipoUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
